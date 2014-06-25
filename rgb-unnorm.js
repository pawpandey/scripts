if (process.argv.length == 6) {
	var normRed = process.argv[2] * 255.0;
	var normGreen = process.argv[3] * 255.0;
	var normBlue = process.argv[4] * 255.0;
	var normAlpha = process.argv[5] * 255.0;

	console.log("new Color(" + normRed + ", " + normGreen + ", " + normBlue + ", " + normAlpha + ");");
} else {
	console.log("Invalid number of color digits");
}