# SpoonTools

A Tools For [Spoon](https://spooncast.net), to Increase Tap Love, Fans, Listener Of Cast, Report, and etc.

This Tools required Authentication ID to send TAP LOVE, Fans, Report.

### ScreenShoots - LATEST Version
![Spoon Tools 1](https://raw.githubusercontent.com/princerayz/SpoonTools/master/ScreenShoots/PictsLatest1.jpg)
![Spoon Tools 2](https://raw.githubusercontent.com/princerayz/SpoonTools/master/ScreenShoots/PictsLatest2.jpg)
![Spoon Tools 3](https://raw.githubusercontent.com/princerayz/SpoonTools/master/ScreenShoots/PictsLatest3.jpg)

### ScreenShoots - OLD Version
![Spoon Tools](https://raw.githubusercontent.com/princerayz/SpoonTools/master/ScreenShoots/Picts.jpg)

## Installation

Download Repository [SpoonTools](https://github.com/princerayz/SpoonTools.git) And Open With Visual Studio

## Requirements

- NET Framework 4.5
- Microsoft.Net.Http
- Newtonsoft.Json

## Features
- Send Tap Love For LIVE Stream, Cast.
- Increase Live Listener (BOT Listener) For Live Stream.
- Report LIVE Stream, Cast, User.
- Increase Cast Listener (1 Listener = 3x Listener Spoon **NO NEED AUTH ID, JUST INPUT CAST ID**).
- Auto Fans User.
- Send Impression to User.
- Batch Load and Get Authentication ID.
- Profile Editor, Name, Profile Pictures, and Password Change.
- Application Thread Handler.

## Instruction To Add Server
```vbnet
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            Server = "https://api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Server = "https://id-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Server = "https://jp-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Server = "https://vn-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            Server = "https://ar-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            Server = "https://us-api.spooncast.net"
        End If
    End Sub
```

### Currently Supported Server [API]
- Spoon Indonesia
- Spoon Korea
- Spoon Japanese
- Spoon Vietnam
- Spoon Arab
- Spoon USA


## Instruction To Add Type

```vbnet
        If ComboBox2.SelectedIndex = 0 Then
            LType = "/casts/"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            LType = "/lives/"
        ElseIf ComboBox2.SelectedIndex = 2 Then
            LType = "/users/"
        End If
```

### Currently Supported Type

- Cast
- Live
- Profile / User / Fans


## Instruction To Change User / Profile Editor
If You Don't want to change Profile Pictures of List BOT / Users, simply comment at this part
```vbnet
dictData.Add("profile_key", "profiles/2/g3PBq2wSZLz4MV/d08b5331-3bab-4439-9f65-2de05c45ec52.jpg")
```

## Just Read This
**Sorry For Messy Coding, I write this project when I'm bored.**
#### Use This At Your Own Risk, If Possible Use Less Report Function !

## Authors

* **PrinceRay** - *Initial work* - [princerayz](https://github.com/princerayz)
 

## License
[MIT License](https://choosealicense.com/licenses/mit/)