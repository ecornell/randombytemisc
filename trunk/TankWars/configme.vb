Option Strict Off
Option Explicit On
Module configme
	'
	' -----------------------------------------------------------
	' The only purpose of this module is to configure your game screen
	' -----------------------------------------------------------
	'
    Public Const hres As Short = 800 ' Horizontal Resolution
    Public Const vres As Short = 600 ' Vertical Resolution

	Public Const depth As Short = 16 ' Bit Depth 16 or 32
    Public Const gamename As String = "Tank Wars"
    Public Const windowedmode As Boolean = False ' True ' False
	Public Const windowcaption As String = gamename
    Public Const viewthelog As Boolean = False ' True or false to view the log at startup
	'
	' -----------------------------------------------------------
	' Important! If your using Windowed Mode make sure to adjust the window in the dxform
	' to be the exact same size as your game resolution. The scalewidth and scaleheight
	' properties are the ones to look at, but don't manually enter values in these
	' properties, just size your window in the ide.
	' -----------------------------------------------------------
	'
End Module