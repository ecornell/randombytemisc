Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class viewlog
	Inherits System.Windows.Forms.Form
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
	
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		viewlogandexit = True
		Me.Close()
	End Sub
	
	
	Private Sub viewlog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim p As String
		'
		p = My.Application.Info.DirectoryPath
		'
		If VB.Right(p, 1) <> "\" Then
			p = p & "\"
		End If
		'
		If LoadFileToTB(Text1, p & "data.log") = False Then
			MsgBox("Data.log not found in root directory.",  , "Log File Not Found")
		End If
		'
	End Sub
	
	Public Function LoadFileToTB(ByRef TxtBox As Object, ByRef FilePath As String, Optional ByRef Append As Boolean = False) As Boolean
		
		'
		' Code courtesy of: http://www.freevbcode.com/ShowCode.asp?ID=466
		'
		Dim iFile As Short
		Dim s As String
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(FilePath) = "" Then Exit Function
		
		On Error GoTo ErrorHandler
		'UPGRADE_WARNING: Couldn't resolve default property of object TxtBox.Text. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		s = TxtBox.Text
		
		iFile = FreeFile
		FileOpen(iFile, FilePath, OpenMode.Input)
		s = InputString(iFile, LOF(iFile))
		If Append Then
			'UPGRADE_WARNING: Couldn't resolve default property of object TxtBox.Text. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBox.Text = TxtBox.Text & s
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object TxtBox.Text. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBox.Text = s
		End If
		
		LoadFileToTB = True
		
ErrorHandler: 
		If iFile > 0 Then FileClose(iFile)
		
	End Function
End Class