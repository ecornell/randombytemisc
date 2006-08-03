Option Strict Off
Option Explicit On
Friend Class dxform
	Inherits System.Windows.Forms.Form
	'
	' This form has code in the query unload event to handle the close message
	'
	
	Private Sub dxform_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'
		If oktoclose = False Then ' We havn't been given the ok to close message yet...
			Cancel = 1
			userwantstoclose = True
		End If
		'
		eventArgs.Cancel = Cancel
	End Sub
End Class