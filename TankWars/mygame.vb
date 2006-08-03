'Option Strict Off
'Option Explicit On
Module mygame
    '
    Public oldplayer_direction As Integer
    Public playerxdir, playerydir As Integer
    Public player_direction As Integer
    Public player_speed As Single
    Public player_step As Single
    Public x2, x1, x3 As Single
    Public cr As String
    Public dmsg As String

    Public player_dspeed As Single

    Public player_dest_x As Single
    Public player_dest_y As Single
    Public player_orig_x As Single
    Public player_orig_y As Single

    'Public player_current_x As Single
    'Public player_current_y As Single

    Public player_XY As DXG.DXGXY

    Public count As Single





    '
    ' --------------------------------------------------------
    ' Your variables should be declared here
    ' --------------------------------------------------------
    '
    '


    Sub GameInit()
        '
        ' -----------------------------------------------------------
        ' Init Your Project Here
        ' -----------------------------------------------------------
        '

        count = 0

        ' load our texture
        dx.Texture.Load(1, "tiles.png")
        dx.Map.InitMapFile("SmallMap1.map")

        dx.Map.SetCameraOnSprite(1)
        ' init our sprite(s)
        dx.Sprite.Init()

        dx.SpriteAnimate.Add(1, 0, 0, 32, 32, 3, "0,1,1,1,2,1", "1,1,1")
        dx.Sprite.Activate(1, 32, 32, 1, 0, 33, 0, 0, 32, 32)
        dx.SpriteAnimate.Repeat(1, 1, 0.01)

        ' this is the arrow on top of the background sprite
        'dx.Sprite.Activate(1, 32, 32, 1, 33, 33, 0, 0, 32, 32)
        ' make the arrow see through
        'dx.Sprite.Alpha(1) = 80
        ' make the arrow rotate in the direction it's moving
        dx.SpriteEngine.SetRotateToDirection(1, 10)


        player_direction = 0
        player_speed = 0.2 ' .05 upto .4 but do not use speeds > .4 otherwise it may not work!


        '
        ' -----------------------------------------------------------
        ' After your game is setup, call the main game loop! :)
        ' -----------------------------------------------------------
        '
        System.Diagnostics.Debug.WriteLine(VB6.TabLayout(dx.Map.GetWidth, dx.Map.GetHeight))
        System.Diagnostics.Debug.WriteLine(VB6.TabLayout(dx.Map.X, dx.Map.Y))
        System.Diagnostics.Debug.WriteLine(dx.Map.Value(1, 1))
        '
        GameLoop()
        '
        ' -----------------------------------------------------------
        ' If you want to return a message that will get displayed, after calling
        ' this routine simply set returnmesssage$ to the string.
        ' You could use this to report errors at load time.
        ' -----------------------------------------------------------
        '
        ' returnmessage = "This is a test of the return message."
        '
    End Sub

    Sub GameLoop()
        '
        ' -----------------------------------------------------------
        ' Before calling this routine make sure your game is initialized
        ' properly in the GameInit routine.
        ' -----------------------------------------------------------
        '
        running = True
        '
        While running = True

            dmsg = Nothing
            '
            ' -----------------------------------------------------------
            ' Handle the window close message.
            ' -----------------------------------------------------------
            '
            If userwantstoclose = True Then
                oktoclose = True
                dxform.Close()
                System.Windows.Forms.Application.DoEvents()
                GoTo exitgameloop
            End If
            '
            ' -----------------------------------------------------------
            ' Pause the game if the window state is minimized
            ' -----------------------------------------------------------
            '
            If dxform.WindowState = 1 Then
                While dxform.WindowState = 1
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            '
            ' -----------------------------------------------------------
            ' Before rendering we always make sure the device is available
            ' This function also handles the auto restore device if lost
            ' In a worse case scenario if the device is fatally lost
            ' you have to exit the program.
            ' -----------------------------------------------------------
            '
            If dx.Scene.Lost = True Then
                GoTo exitgameloop ' We have fatally lost the device, no escape!
            End If
            '
            ' -----------------------------------------------------------
            ' Prepare the next scene
            ' -----------------------------------------------------------
            '
            dx.Scene.Begin()
            '
            ' -----------------------------------------------------------
            ' Handle some generic key presses for exit, scene info, fps
            ' -----------------------------------------------------------
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_ESCAPE) = True Then
                running = False ' ESC is a standard to exit a DXGame App ;)
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_ESCAPE)
            End If
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F1) = True Then ' Toggle Scene Info
                dx.Scene.SceneInfo = Not dx.Scene.SceneInfo
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F1)
            End If
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F2) = True Then ' Run at 20fps
                dx.Scene.FrameRate = 20
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F2)
            End If
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F3) = True Then ' Run at 30fps
                dx.Scene.FrameRate = 30
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F3)
            End If
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F4) = True Then ' Run at 60fps
                dx.Scene.FrameRate = 60
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F4)
            End If
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F5) = True Then
                dx.Scene.FrameRate = 0 ' Reset to no throttle
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F5)
            End If
            '
            ' -----------------------------------------------------------
            ' Code your game structure here
            ' -----------------------------------------------------------
            '

            'dmsg += "ToX=" & CStr(dx.Map.GetSpriteToXPixel(1, CSng(0.2 * dx.Delta)))
            'dmsg += " ToY=" & CStr(dx.Map.GetSpriteToYPixel(1, CSng(0.2 * dx.Delta)))

            'player_dspeed = player_speed * dx.Delta

            'player_current_x = dx.Map.GetSprite ToXPixel(1)
            'player_current_y = dx.Map.GetSpriteToYPixel(1)

            player_XY = dx.Map.GetSpriteToXYPixel(1)


            dmsg += " CToX=" & player_XY.X
            dmsg += " CToY=" & player_XY.Y

            'dmsg += " m=" & player_moving
            'dmsg += " d=" & player_direction

            'dmsg += " s=" & player_speed
            'dmsg += " ds=" & player_dspeed

            If Not dx.SpriteEngine.IsMoving(1) Then

                If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_W) = True Then
                    ' UP
                    If dx.Map.GetAtSprite(1, 0, -1) < 2 AndAlso dx.Map.GetAtSprite(1, 31, -1) < 2 Then
                        player_direction = 1

                        player_dest_x = player_XY.X
                        player_dest_y = player_XY.Y - 32

                        dx.SpriteEngine.MoveToXY(1, player_dest_x, player_dest_y, player_speed)

                    End If
                    '
                End If
                '
                If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_S) = True Then
                    ' DOWN
                    If dx.Map.GetAtSprite(1, 0, 32) < 2 AndAlso dx.Map.GetAtSprite(1, 31, 32) < 2 Then
                        player_direction = 2

                        player_dest_x = player_XY.X
                        player_dest_y = player_XY.Y + 32

                        dx.SpriteEngine.MoveToXY(1, player_dest_x, player_dest_y, player_speed)

                    End If
                    '
                End If
                '
                If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_D) = True Then
                    ' RIGHT
                    If dx.Map.GetAtSprite(1, 32, 0) < 2 AndAlso dx.Map.GetAtSprite(1, 32, 31) < 2 Then
                        player_direction = 3

                        player_dest_x = player_XY.X + 32
                        player_dest_y = player_XY.Y

                        dx.SpriteEngine.MoveToXY(1, player_dest_x, player_dest_y, player_speed)

                    End If
                    '
                End If
                '
                If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_A) = True Then
                    ' LEFT
                    If dx.Map.GetAtSprite(1, -1, 0) < 2 AndAlso dx.Map.GetAtSprite(1, -1, 31) < 2 Then
                        player_direction = 4

                        player_dest_x = player_XY.X - 32
                        player_dest_y = player_XY.Y

                        dx.SpriteEngine.MoveToXY(1, player_dest_x, player_dest_y, player_speed)

                    End If
                    '
                End If

            End If


            'dmsg += "   DToX=" & player_dest_x
            'dmsg += " DToY=" & player_dest_y

            'dmsg += "   SX=" & Math.Floor(d.X)
            'dmsg += " SY=" & Math.Floor(d.Y)


            '
            ' -----------------------------------------------------------
            ' Render everthing as needed, in any order as needed ;)
            ' -----------------------------------------------------------
            '

            dx.Map.Render()
            dx.Sprite.Render()


            dx.Text.Render(20, 20, 600, 50, dmsg, DXG.DXGTextFormat.AlignLeft, dx.Lib.GetARGBColor(255, 255, 0, 0), "Times New Roman", 8, False, False, 0, 0, 0)

            '
            ' -----------------------------------------------------------
            ' Save a screenshot of your game as .bmp file
            ' -----------------------------------------------------------
            '
            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_F12) = True Then
                dx.Key.Clear(DxVBLibA.CONST_DIKEYFLAGS.DIK_F12)
                dx.Lib.SaveScreenShot()
            End If


            If dx.Key.Pressed(DxVBLibA.CONST_DIKEYFLAGS.DIK_R) = True Then
                count = 0
            End If
            '
            ' -----------------------------------------------------------
            ' Finally, display your scene
            ' -----------------------------------------------------------
            '
            dx.Scene.Render()
            '
        End While
        '
exitgameloop:
        '
    End Sub
End Module