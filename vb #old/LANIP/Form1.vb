Imports System.Net
Public Class Form1
    Dim i As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListBox1.Items.Add("Hostname: " & Dns.GetHostName)
            Console.WriteLine("Hostname: " & Dns.GetHostName)
            ListBox1.Items.Add("----------------------------------------------------------------------")
            Console.WriteLine("----------------------------------------------------------------------")
            For index = 1 To 99
                ListBox1.Items.Add(CType(Dns.GetHostEntry(Dns.GetHostName).AddressList.GetValue(i), IPAddress).ToString)
                Console.WriteLine(CType(Dns.GetHostEntry(Dns.GetHostName).AddressList.GetValue(i), IPAddress).ToString)
                i = i + 1
                Status.Text = "Grabbed " & i & " IPs"
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Clipboard.SetText(ListBox1.SelectedItem)
            Status.Text = "Copied " & Clipboard.GetText & " to clipboard"
        Catch ex As Exception
        End Try
    End Sub
End Class
