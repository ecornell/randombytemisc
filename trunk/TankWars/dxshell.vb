Option Strict Off
Option Explicit On
Module dxshell
	'
	' -----------------------------------------------------------
	' This module initializes the DXGame Engine and the interface. After the
	' interface is setup, program control will be passed to you via the
	' "GameInit" routine inside mygame.bas
	'
	' Make sure under "Project-References" you have the following selected:
	' OLE Automation
	' DXGame 2D Engine  (dxg.dll)
	' DirectX 8 For Visual Basic Type Library
	' -----------------------------------------------------------
	'
	Public dx As DXG.DXGameEngine
	Public userwantstoclose As Boolean
	Public oktoclose As Boolean
	Public returnboolean As Boolean
	Public returnlong As Integer
	Public returnmessage As String
	Public running As Boolean
	Public viewlogandexit As Boolean
	'
	' -----------------------------------------------------------
	' Please do not enter any code below this line.
	' -----------------------------------------------------------
	'
	
	Public Sub Main()
        '
        ' -----------------------------------------------------------
        ' Under normal conditions you don't have to edit anything in this routine.
        ' -----------------------------------------------------------
        '
        If viewthelog = True Then
            viewlog.ShowDialog()
            If viewlogandexit = True Then
                GoTo shellexit
            End If
        End If
        '
        returnmessage = ""
        '
        If windowedmode = True Then
            dxform.Show()
            dxform.Text = windowcaption
            System.Windows.Forms.Application.DoEvents()
        End If
        '
        dx = New DXG.DXGameEngine
        '
        dx.Path = My.Application.Info.DirectoryPath
        '
        returnboolean = dx.Init(dxform.Handle.ToInt32, hres, vres, depth, windowedmode, 0, True, False)

        '
        If returnboolean = True Then
            GameInit()
        Else
            MsgBox("Error. - The DirectX interface could not be initialized.", , "DXGame Engine")
        End If
        '
        dx.Terminate()
        '
        dx = Nothing
        '
        If windowedmode = True Then
            dxform.Visible = False
            System.Windows.Forms.Application.DoEvents()
        End If
        '
        dxform.Close()
        System.Windows.Forms.Application.DoEvents()
        '
        If returnmessage <> "" Then
            msg.ShowDialog()
        End If
        '
shellexit:
        '
        System.Windows.Forms.Application.DoEvents()
        End
        '
    End Sub
End Module