Imports System.Runtime.CompilerServices

Module StringExtension
    <Extension()>
    Public Function GetLastNumber(ByVal s As String) As Integer
        Dim numberString = String.Empty
        For i As Integer = s.Length - 1 To 0 Step -1
            If Char.IsDigit(s(i)) Then
                numberString = s(i) + numberString
            Else
                Exit For
            End If
        Next

        Return Integer.Parse(numberString)
    End Function

    <Extension()>
    Public Function GetFirstNumber(ByVal s As String) As Integer
        Dim numberString = String.Empty
        For i As Integer = 0 To s.Length - 1 Step 1
            If Char.IsDigit(s(i)) Then
                numberString = numberString + s(i)
            Else
                Exit For
            End If
        Next

        Return Integer.Parse(numberString)
    End Function

    <Extension()>
    Public Function RemoveDigits(ByVal s As String) As String
        Dim newString = String.Empty
        For i As Integer = 0 To s.Length - 1
            If Not Char.IsDigit(s(i)) Then
                newString = newString + s(i)
            End If
        Next

        Return newString
    End Function



    Public Function IsDigit(ByVal c As Char) As Boolean
        Return c >= "0" And c <= "9"
    End Function


End Module
