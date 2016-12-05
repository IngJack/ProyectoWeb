Public Class Form1
    Dim FICHERO As String
    Dim ARCHIVOS As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
    Dim CONTADOR As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CONTADOR = 0
        FlowLayoutPanel1.Controls.Clear()
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FICHERO = FolderBrowserDialog1.SelectedPath
            ARCHIVOS = My.Computer.FileSystem.GetFiles(FICHERO)

            Timer1.Enabled = True
            Button1.Enabled = False
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CONTADOR <= ARCHIVOS.Count - 1 Then
            If ARCHIVOS(CONTADOR).Contains(".jpg") Or ARCHIVOS(CONTADOR).Contains(".png") Or ARCHIVOS(CONTADOR).Contains(".gif") Then
                Dim PB As New PictureBox

                PB.Name = "PB" & CONTADOR
                PB.Width = 160
                PB.Height = 120
                PB.SizeMode = PictureBoxSizeMode.Zoom
                PB.Image = System.Drawing.Bitmap.FromFile(ARCHIVOS(CONTADOR))
                AddHandler PB.Click, New System.EventHandler(AddressOf PB_Click)
                FlowLayoutPanel1.Controls.Add(PB)
                CONTADOR += 1
            Else
                CONTADOR += 1
            End If
        Else
            Timer1.Enabled = False
            Button1.Enabled = True

        End If
    End Sub
    Private Sub PB_Click(sender As Object, e As EventArgs)
        Dim PIC As PictureBox = TryCast(sender, PictureBox)
        IMAGEN.PictureBox1.Image = PIC.Image
        IMAGEN.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FlowLayoutPanel1.Controls.Clear()
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FICHERO = FolderBrowserDialog1.SelectedPath
            ARCHIVOS = My.Computer.FileSystem.GetFiles(FICHERO)

            For I = 0 To ARCHIVOS.Count - 1
                If ARCHIVOS(I).Contains(".jpg") Or ARCHIVOS(I).Contains(".png") Or ARCHIVOS(I).Contains(".gif") Then

                    Dim PB As New PictureBox

                    PB.Name = "PB" & I
                    PB.Width = 160
                    PB.Height = 120
                    PB.SizeMode = PictureBoxSizeMode.Zoom
                    PB.Image = System.Drawing.Bitmap.FromFile(ARCHIVOS(I))
                    AddHandler PB.Click, New System.EventHandler(AddressOf PB_Click)
                    FlowLayoutPanel1.Controls.Add(PB)
                End If
            Next

        End If

    End Sub
End Class
