Public Class ParkGame
    Dim TREE As Image = Image.FromFile("Tree.gif")
    Dim ROWS As Integer = 4, COLUMNS As Integer = 7, REGIONS As Integer = 4
    Dim PARK(,) As Integer = {
        {0, 0, 0, 2, 2, 2, 2},
        {0, 0, 0, 3, 2, 2, 2},
        {0, 1, 1, 3, 3, 3, 2},
        {1, 1, 1, 3, 3, 3, 3}
    }
    Dim cells(ROWS, COLUMNS) As Button
    Dim R(ROWS), C(COLUMNS), D1(ROWS + COLUMNS - 1), D2(ROWS + COLUMNS - 1), RG(REGIONS) As Boolean
    Dim trees(ROWS, COLUMNS), gameOver As Boolean
    Dim treesCnt As Integer

    Private Sub ParkGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To ROWS - 1
            For j = 0 To COLUMNS - 1
                cells(i, j) = DirectCast(Controls.Find("cell" & i & j, False).First, Button)
                trees(i, j) = False
            Next
        Next
        For i = 0 To ROWS - 1
            R(i) = True
        Next
        For i = 0 To COLUMNS - 1
            C(i) = True
        Next
        For i = 0 To ROWS + COLUMNS - 2
            D1(i) = True
            D2(i) = True
        Next
        For i = 0 To REGIONS - 1
            RG(i) = True
        Next
        treesCnt = 0
        gameOver = False
    End Sub

    Private Sub button_Click(sender As Object, e As EventArgs) Handles cell36.Click, cell35.Click, cell34.Click, cell33.Click, cell32.Click, cell31.Click, cell30.Click, cell26.Click, cell25.Click, cell24.Click, cell23.Click, cell22.Click, cell21.Click, cell20.Click, cell13.Click, cell16.Click, cell15.Click, cell14.Click, cell12.Click, cell11.Click, cell10.Click, cell06.Click, cell05.Click, cell04.Click, cell03.Click, cell02.Click, cell01.Click, cell00.Click
        If Not gameOver Then
            Dim cellName As String = CType(sender, Button).Name
            Dim cellNum As Integer = CType(cellName.Substring(4), Integer)
            Dim row As Integer = cellNum \ 10, col As Integer = cellNum Mod 10
            Dim region As Integer = PARK(row, col)
            If R(row) And C(col) And D1((COLUMNS - 1) + row - col) And D2(row + col) And RG(region) Then
                cells(row, col).Image = TREE
                trees(row, col) = True
                R(row) = False
                C(col) = False
                D1((COLUMNS - 1) + row - col) = False
                D2(row + col) = False
                RG(region) = False
                treesCnt += 1
            ElseIf trees(row, col) Then
                cells(row, col).Image = Nothing
                trees(row, col) = False
                R(row) = True
                C(col) = True
                D1((COLUMNS - 1) + row - col) = True
                D2(row + col) = True
                RG(region) = True
                treesCnt -= 1
            Else
                MessageBox.Show("Occupied")
            End If
            If treesCnt = REGIONS Then
                gameOver = True
                MessageBox.Show("Solved!")
            End If
        End If
    End Sub

    Private Sub restartBtn_Click(sender As Object, e As EventArgs) Handles restartBtn.Click
        For i = 0 To ROWS - 1
            For j = 0 To COLUMNS - 1
                cells(i, j).Image = Nothing
                trees(i, j) = False
            Next
        Next
        For i = 0 To ROWS - 1
            R(i) = True
        Next
        For i = 0 To COLUMNS - 1
            C(i) = True
        Next
        For i = 0 To ROWS + COLUMNS - 2
            D1(i) = True
            D2(i) = True
        Next
        For i = 0 To REGIONS - 1
            RG(i) = True
        Next
        treesCnt = 0
        gameOver = False
    End Sub
End Class
