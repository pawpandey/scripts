### Mon, Jan  4, 2016  2:22:06 PM
- PS-6558 [Unit Manager] Add Magnifier to Unit Manager
    - Emulate gacha functionality

### Mon, Dec 21, 2015 12:09:55 PM
- Task   PS-6269 Optimize narrators

### Fri, Dec 18, 2015 12:49:47 PM
- PS-6924 [Onboarding] Strike Unit Manufacturing from the onboarding.
- Bug    PS-6977 [Onboarding] For second tile, title appears as 'Mission:' (no name)

### Fri, Dec 18, 2015 11:37:29 AM
- Bug    PS-6955 Crashlytics iOS 3.6: FindPartPopup

### Wed, Dec 16, 2015  9:21:44 AM
- Bug    PS-6471 [Onboarding][Unit Manager][Rank Up] Rank up tutorial does not trigger
    - How to trigger rank up tutorial:
    - Step 30 uncomplete  
    - Funnel complete
    - If a selected unit in the UnitManagementSet needs a ptoken
    - When it's fully leveled up
    - Reasons why this won't trigger:
    - Are we on UnitManagementSet when the check happens?
        - Not anymore, but Abhi updated the UnitManagementSet inst interface
        - Is the unit actually selected when we make the check?
        - Does the unit actually require a ptoken when we need to rank up?
- Bug    PS-6453 [Onboarding] Equip-a-unit tutorial and upgrade-a-unit tuorial trigger at the same time
- Bug    PS-6437 [Mission Briefing] [Tutorial] The back/home tab is inoperable after finishing the tutorial for unit assignments.
- Bug    PS-6347 [Hangar] Put NPC Commanders on the right side of the Hangar.
- Bug    PS-6428 [Hangar] The 'Rank Up' tutorial does NOT update dynamically when player changes unit.
- Bug    PS-5773 [Onboarding] Leveling material tutorial does not trigger as intended
- Bug    PS-3298 [Splash Screen] New profile, flicker issue upon pressing the PLAY button for the first time
- Onboarding arrows to no longer use string names
- Gacha tutorial to have scrolling fixed
- Task   PS-6269 Optimize narrators
- Bug    PS-5544 [onboarding] Separate 'squadSelectSet' into pvp and campaign versions
- Bug    PS-3163 Pvp screen contents tutorial
- Refactor step 14 
- Bug    PS-5404 Clean up GoToSet/WaitForSet in Onboarding
- Bug    PS-5403 Converge the two GoToSet functions
- Bug    PS-5314 Check for duplicate step names when marking analytics
- Bug    PS-5264 One frame pops
- PS-6335 Fix the requirements/fulfillments for onboarding steps
- Add onboarding step stack trace logging for device
- Add onboarding step check logging for device
- Machine shop prompt appeared with the rate app popup
- Tech tutorial prompts on frame and not button
- Onboarding unstuck debug button"

### Tue, Dec  1, 2015  8:53:06 PM
- Task   PS-6080 Turn off Chat during Onboarding

### Tue, Dec  1, 2015  7:55:28 PM
- Temp back buttons need to be removed from sets, and use the canonic StatsBar button instead
    -Search for prefabs looking at the homebutton sprite guid
    -The RateAppPopup
    -Remove IBackButtonTemp
    -Remove BackButon game objects

### Tue, Dec  1, 2015  5:07:07 PM
- PS-6383 [Mission Briefing][Tutorial] Repair Tutorial arrow overlaps tutorial text.
- Repair tutorial requires:
    - Squad damaged
    - Funnel complete
    - 31 uncomplete

### Mon, Nov 30, 2015  6:11:52 PM
- Bug    PS-6224 [Tech Tutorial] The unit 'Upgrading' panel displays over the empty 'Tech Slot' during Tech tutorial.
    - Tech tutorial fast unlock
        - Requires:
            - Hangar lv 3
            - Step 24 uncomplete
            - Active squad has a unit
            - Player is level > 6
            - Player's tech count > 1
            - Funnel is complete
    - Make sure that level up buildings is not broken by this change

### Wed, Nov 25, 2015  3:24:51 PM
- Bug    PS-6322 Squad damage tutorial has an arrow that points at nothing
    - Repair step is 31
        - Requires:
            - Funnel complete
            - Active squad damaged
            - SquadSelectSet

### Wed, Nov 25, 2015  1:49:01 PM
- Bug    PS-6293 [Onboarding] Sometimes, the first enemy unit deploys too soon

### Wed, Nov 25, 2015 12:05:24 PM
- Step 8 fast unlock
- Bug    PS-5569 [Onboarding][Squad Slot Tutorial] Tap arrow appears briefly, then disappears

### Sat, Nov 21, 2015  4:42:28 PM
- PS-6120 [Onboarding] The user is taken back to HQ after manufacturing a unit during onboarding. Blake 
- PS-6129 [Onboarding] [Machine Shop] Missing instructions when entering the Machine Shop.    Blake Triana    David Randolph  High
- PS-6159 [Onboarding][GACHA] The bonus container header is overlapped by the top UI bar  Blake Triana    Misha Sawangwan High

#### Fri, Nov 20, 2015  6:09:24 PM
- Manufacturing step hangs:
    - Trace: Step4.cs 92
    - Trace: Step4.cs 128
    - What does a fresh player need in order to do manufacturing tutorial?
        - Mantis blueprint
        - Mantis resources
        - Step4 uncompleted

### Fri, Nov 20, 2015  6:09:24 PM
- Debug Menu Manager leaks the category window
