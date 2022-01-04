# KeyCardPermissions
Modify KeyCard Permissions Exiled4+

![KEYCARDPERMISSIONS LATEST](https://img.shields.io/github/v/release/Undid-Iridium/KeyCardPermissions?include_prereleases&style=flat-square)
![KEYCARDPERMISSIONS LINES](https://img.shields.io/tokei/lines/github/Undid-Iridium/KeyCardPermissions)
![KEYCARDPERMISSIONS DOWNLOADS](https://img.shields.io/github/downloads/Undid-Iridium/KeyCardPermissions/total?style=flat-square)


# Installation

**[EXILED](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "KeyCardPermissions.dll" file in your Plugins folder.



## Config
What ghosts can interact with is not shown on this list but is configurable and will be generated along with the rest of these settings.
| Keycard Configuration      | Value Type | Keycard_Perms | Value Type | Description                                            |
|----------------------------|------------|---------------|------------|--------------------------------------------------------|
| KeycardJanitor             | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardScientist           | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardResearchCoordinator | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardZoneManager         | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardGuard               | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardNTFOfficer          | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardContainmentEngineer | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardNTFLieutenant       | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardNTFCommander        | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardFacilityManager     | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardChaosInsurgency     | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |
| KeycardO5                  | RoleType   | See below     | ushort arr | Determines the permissions on the card                 |

Solution 1:

Hijack with Harmony to modify the default item list permissions. Expenisve once, and only once, very small <50ms 
Keycard_Config : true <=== What is default, and what you need to set


```
	//All possible permissions
	public enum KeycardPermissions : ushort
	{
		// Token: 0x04002646 RID: 9798
		None = 0,
		// Token: 0x04002647 RID: 9799
		Checkpoints = 1,
		// Token: 0x04002648 RID: 9800
		ExitGates = 2,
		// Token: 0x04002649 RID: 9801
		Intercom = 4,
		// Token: 0x0400264A RID: 9802
		AlphaWarhead = 8,
		// Token: 0x0400264B RID: 9803
		ContainmentLevelOne = 16,
		// Token: 0x0400264C RID: 9804
		ContainmentLevelTwo = 32,
		// Token: 0x0400264D RID: 9805
		ContainmentLevelThree = 64,
		// Token: 0x0400264E RID: 9806
		ArmoryLevelOne = 128,
		// Token: 0x0400264F RID: 9807
		ArmoryLevelTwo = 256,
		// Token: 0x04002650 RID: 9808
		ArmoryLevelThree = 512,
		// Token: 0x04002651 RID: 9809
		ScpOverride = 1024
	}
	
	//All possible KeyCard roles
	KeycardJanitor
	KeycardScientist
	KeycardResearchCoordinator
	KeycardZoneManager
	KeycardGuard
	KeycardNTFOfficer
	KeycardContainmentEngineer
	KeycardNTFLieutenant
	KeycardNTFCommander
	KeycardFacilityManager
	KeycardChaosInsurgency
	KeycardO5
```
Current version
``` 


  card_permissions:
    KeycardJanitor:
    - 16
    KeycardScientist:
    - 1
    - 2
    - 4
    - 8
    - 16
    - 32
    - 64
    - 128
    KeycardResearchCoordinator:
    - 1
    - 16
    - 32
    KeycardZoneManager:
    - 1
    - 16
    KeycardGuard:
    - 1
    - 16
    - 128
    KeycardNTFOfficer:
    - 1
    - 16
    - 32
    - 128
    - 256
    KeycardContainmentEngineer:
    - 1
    - 16
    - 32
    - 64
    KeycardNTFLieutenant:
    - 1
    - 2
    - 16
    - 32
    - 128
    - 256
    KeycardNTFCommander:
    - 1
    - 2
    - 4
    - 16
    - 32
    - 128
    - 256
    - 512
    KeycardFacilityManager:
    - 1
    - 2
    - 4
    - 8
    - 16
    - 32
    - 64
    KeycardChaosInsurgency:
    - 1
    - 2
    - 4
    - 16
    - 32
    - 128
    - 256
    - 512
    KeycardO5:
    - 1
    - 2
    - 4
    - 8
    - 16
    - 32
    - 64
    - 128
    - 256
    - 512
    
```

Previous version: 

```
	
	Default permissions
	{ "KeycardJanitor" ,  "16" },
	{ "KeycardScientist" ,  "16,32" },
	{ "KeycardResearchCoordinator" ,  "1,16,32" },
	{ "KeycardZoneManager" ,  "1,16" },
	{ "KeycardGuard" ,  "1,16,128" },
	{ "KeycardNTFOfficer" ,  "1,16,32,128,256" },
	{ "KeycardContainmentEngineer" ,  "1,16,32,64" },
	{ "KeycardNTFLieutenant" ,  "1,2,16,32,128,256" },
	{ "KeycardNTFCommander" ,  "1,2,4,16,32,128,256,512" },
	{ "KeycardFacilityManager" ,  "1,2,4,8,16,32,64" },
	{ "KeycardChaosInsurgency" ,  "1,2,4,16,32,128,256,512" },
	{ "KeycardO5" ,  "1,2,4,8,16,32,64,128,256,512" }

	
```



Option 2 is if you use Exiled KeyCardItem (Or Keycard class under features.items) then you just need to set the option 2 and it'll hijack your player spawn, access the inventory, remove the current card, replace card with new keycard with new permissions. Not cheap but possible, seems expensive for 32+ players.
Door_Config : false <=== What is default, and what you need to set


Option 3 is if you want a simplistic solution, I will provide logic so that doors just accept certain cards. Cheaper than option 2 but more prone to breaking with newer changes, door changes, etc. I would say this is middle ground option
Spawn_Config : false <=== What is default, and what you need to set


IF; however, you have a plugin that adds new cards, I will attempt to apply the change per the card name, so it MUST match. 
This also assumes they did the correct way of adding new objects instead of doing it post setup. 
AKA, I do a harmony patch at the very start of loading, if there is a need for post-support that's fine and I can add a feature flag for that if requested. 
All that would need to be done is code call to forceReload that'll cause all items to reload with my patch. 

For now, Only option 1 is coded. I did this in the last 5 hours so I am tired, options 2 and 3 will not be added. Upon doing the research for them, it seems counter-intuitive to use anything OTHER than a harmony patch. Option 2 would be as easy as the patch but would potentially need to occur as often (Since the object is public, update the instance in the same manner as I did with the harmony patch; however, why do that if the harmony patch works). I did have this working; however, why have this when you can have the harmony patch once. Option 3 doesn't have the same problem as 2 in term of repeatability but why make the server work harder to figure out what card refers to what item, etc. If 2 or 3 is ever desired, make an issue; otherwise, I consider the harmony patch the best approach. Thanks!


![image](https://user-images.githubusercontent.com/24619207/147803086-ad12faa4-fb1c-462f-841d-ae5899240009.png)

![image](https://user-images.githubusercontent.com/24619207/147803089-7e585c19-65e8-4c2d-a3c0-b7eb3c07d2c3.png)

