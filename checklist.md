# Checklist

- ScrollRect optimization
    - Top-down implementation
    - Extract out CardSmall
    - Create LibraryGridLayout
        - Replaces the VerticalLayoutGroup and the GridLayoutGroup
- ScrollToChild should guarantee position        
    - LayoutRebuilder.ForceRebuild
- Separate out OnboardingCoroutine from the rest of Onboarding
    - CustomYieldInstructions for the Onboarding WaitFors
- Completed onboarding steps reappear on users while server data is deployed during their session

# Someday Maybe

- Merge GoToSet functions
- Use a Json serialized class for the localization enum
    - Make editor recompile on users pulling loc
    - Support extra error checking for compiling LocEnum
- Multi-day soak tests for onboarding 
- Reverse support for texted arrows http://i.imgur.com/eiI5SzX.png
- Pointing fingers not always show in HQ   
- Make sure bundle downloading at funnel end visually appears how you would expect it to
- Frame pops
    - Step 14 begin
    - Resource generator tutorial
    - Frame pop during step 1
- Jenkins Pinata machine
- Onboarding has a one frame window where users can click things (promotion tutorial)
- Disconnect battle 1 during Narrator -> Could not click
- PopToSet syntax for Onboarding
- Narrator lingers after returning to HomeBase from campaign
- Speed for debug menu
- Autobattle for debug menu
- Oren about gameplay connection first time
- Fix onboarding stuck
    - Long touch for debug menu
