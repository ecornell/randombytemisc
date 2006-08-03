Option Strict Off
Option Explicit On
Friend Class msg
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
	
	Private Sub msg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Text = gamename
		Label1.Text = returnmessage
	End Sub
End Class