Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading

Public Class Form1
    Delegate Sub changeText1ControlDelegate(ByVal treeview1 As TreeView, ByVal s As String)
    Dim status As Boolean = True


    Public Sub setdisplaytext1(ByVal treeview1 As TreeView, ByVal s As String)
        MsgBox("ouch")
        Try
            Dim f As Array
            Dim b = 0
            treeview1.Nodes.Clear()
            f = s.Split("|")
            For b = 0 To f.Length
                treeview1.Nodes.Add(f(b))

            Next

        Catch ffff As Exception
            System.Console.Write("fff")
        End Try

    End Sub

    Private Sub scanit()

        While status = True
            Dim s As String = ""
            Dim sf As String = ""
            Dim g As Integer
            For g = 1 To 254

                Dim myProcess As Process = New Process()

                Dim it As String = "-w 5 -n 1 192.168.10." & g

                myProcess.StartInfo.FileName = "ping.exe"
                myProcess.StartInfo.UseShellExecute = False
                myProcess.StartInfo.CreateNoWindow = True
                myProcess.StartInfo.Arguments = it
                myProcess.StartInfo.RedirectStandardInput = True
                myProcess.StartInfo.RedirectStandardOutput = True
                myProcess.StartInfo.RedirectStandardError = True
                myProcess.Start()
                Dim sIn As StreamWriter = myProcess.StandardInput
                sIn.AutoFlush = True

                Dim sOut As StreamReader = myProcess.StandardOutput
                Dim sErr As StreamReader = myProcess.StandardError
                sIn.Write("dir c:\windows\system32\*.com" & _
                   System.Environment.NewLine)
                sIn.Write("exit" & System.Environment.NewLine)
                sf = sOut.ReadToEnd()
                If Not myProcess.HasExited Then
                    myProcess.Kill()
                End If
                If sf.Contains("Reply") Then
                    s = s & "|" & "192.168.10." & g
                End If

                sIn.Close()
                sOut.Close()
                sErr.Close()
                myProcess.Close()
            Next

            If Me.TreeView1.InvokeRequired Then
                Me.TreeView1.Invoke(New changeText1ControlDelegate(AddressOf setdisplaytext1), New Object() {TreeView1, s})

            Else
                Me.setdisplaytext1(TreeView1, s)
            End If
            System.Threading.Thread.Sleep(5000)
        End While
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim scan As New Threading.Thread(AddressOf scanit)
        scan.Start()
      
    End Sub
End Class
