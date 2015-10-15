import subprocess
import sys
import time


def build_unity_player(input_str):
    unity_app = "/Applications/Unity/Unity.app/Contents/MacOS/Unity"
    args = [unity_app] + input_str.split(" ")
    print "args: %r" % args
    # args.append("-quit")
    # args.append("-batchmode")
    # args.append("-projectPath")
    # args.append("/Users/oren/unity/shadow/trunk")
    # args.append("-executeMethod")
    # args.append("CommandLine.PerformBuild")
    # args.append("-platform=iOS")
    # args.append("-buildconfig=DebugOptimized")

    # Find log file
    unity_log_file = "/Users/Blake/Library/Logs/Unity/Editor.log"
    # if "-logFile" in input_str:
    #     unity_log_file = input_str.split("-logFile ")[1].split(" ")[0]

    print "unity_log_file: %r" % unity_log_file

    # Start the process
    process = subprocess.Popen(args, stderr=subprocess.PIPE, stdout=subprocess.PIPE)

    fail_strings = ["Build.Builder Succeeded: False",
                    "Launching bug reporter",
                    "Scripts have compiler errors",
                    "Error building Player",
                    "Aborting batchmode due to failure"]

    success_string = "Build.Builder Succeeded: True"

    # Wait a bit to skip last success / failure message and open the correct log file
    for i in range(10):
        print "Starting up... %d / 10" % i
        time.sleep(1)

    # Open log file
    with open(unity_log_file) as f:
        print "Log file open"

        # Go to end of file
        f.seek(0, 2)

        # Wait on Unity
        while process.poll() is None:

            # Read line
            line = f.readline()

            # If failed, sleep
            if not line:
                time.sleep(1)

            # Read a line
            else:
                sys.stdout.write(line)

                # Search lines for success
                if success_string in line:
                    process.terminate()
                    print "==== success! ===="
                    return 0

                # Or failure
                for fail_string in fail_strings:
                    if fail_string in line:
                        process.terminate()
                        print "==== failure! ===="
                        return 1

    # If ended on it's own, verify was succesful
    with open(unity_log_file) as f:
        f.seek(-3000, 2)
        lastData = f.read()
        print lastData
        if success_string in lastData:
            process.terminate()
            print "==== success! (proc ended) ===="
            return 0

    # Could not find success signal
    print "==== failure! (proc ended) ===="
    return 1

if __name__ == '__main__':
    input_str = """-quit -batchmode -executeMethod CommandLine.PerformBuild -platform=iOS -buildconfig=Optimized -makeobb=False"""
    # input_str = """-quit -batchmode -executeMethod CommandLine.PerformBuild -platform=iOS -buildconfig=DebugOptimized -makeobb=False"""
    # input_str = sys.argv[1]
    for i in range(0, 3):
        print "===== Trying %d / 3 =====" % i
        result = build_unity_player(input_str)
        if result == 0:
            exit(0)
    exit(1)
