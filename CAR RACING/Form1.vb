Public Class Form1
    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim score As Integer = 0


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
    End Sub

    Private Sub RoadMover_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoadMover.Tick
        For x As Integer = 0 To 7
            road(x).Top += speed
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height
            End If
        Next

        If score > 10 And score < 30 Then
            speed = 7
        End If
        If score > 30 And score < 50 Then
            speed = 9
        End If
        If score > 50 And score < 70 Then
            speed = 11
        End If
        If score > 100 Then
            speed = 13
        End If

        Label2.Text = "Speed" & speed
        If (car.Bounds.IntersectsWith(race1.Bounds)) Then
            endgame()
        End If
        If (car.Bounds.IntersectsWith(race2.Bounds)) Then
            endgame()
        End If
        If (car.Bounds.IntersectsWith(race3.Bounds)) Then
            endgame()
        End If
    End Sub
    Private Sub endgame()
        Button1.Visible = True
        Label3.Visible = True
        RoadMover.Stop()
        RaceMover1.Stop()
        RaceMover2.Stop()
        RaceMover3.Stop()

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            RightSide.Start()

        End If

        If e.KeyCode = Keys.Left Then
            LeftSide.Start()
        End If
    End Sub


    Private Sub RightSide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightSide.Tick
        If (car.Location.X < 295) Then
            car.Left += 5
        End If
    End Sub

    Private Sub LeftSide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftSide.Tick
        If (car.Location.X > 0) Then
            car.Left -= 5
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        RightSide.Stop()
        LeftSide.Stop()
    End Sub

    Private Sub RaceMover1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RaceMover1.Tick
        race1.Top += speed / 2
        If race1.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score" & score

            race1.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race1.Height)
            race1.Left = CInt(Math.Ceiling(Rnd() * 50)) + 0
        End If
    End Sub

    Private Sub RaceMover2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RaceMover2.Tick
        race2.Top += speed / 3
        If race2.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score" & score

            race2.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race2.Height)
            race2.Left = CInt(Math.Ceiling(Rnd() * 50)) + 100
        End If
    End Sub

    Private Sub RaceMover3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RaceMover3.Tick
        race3.Top += speed * 1 / 2
        If race3.Top >= Me.Height Then
            score += 1
            Label1.Text = "Score" & score

            race3.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race3.Height)
            race3.Left = CInt(Math.Ceiling(Rnd() * 120)) + 180
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub
End Class
