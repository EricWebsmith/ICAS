Imports System.IO
Imports System.Xml.Linq

Module rsRobotHtml

    Public Sub Clean1()
        Dim content As String

        Using reader As StreamReader = New StreamReader("C:\Eric\1.html")
            content = reader.ReadToEnd()
            reader.Close()
        End Using

        Dim newContent = content.Replace("&nbsp;", "")

        Using writer As StreamWriter = New StreamWriter("C:\Eric\2.html")
            writer.Write(newContent)
            writer.Flush()
            writer.Close()

        End Using

    End Sub

    Public Sub Clean2()
        Dim content As String

        Using reader As StreamReader = New StreamReader("C:\Eric\2.html")
            content = reader.ReadToEnd()
            reader.Close()
        End Using

        Dim newContent = content.Replace("<br>", "<br />")

        Using writer As StreamWriter = New StreamWriter("C:\Eric\3.html")
            writer.Write(newContent)
            writer.Flush()
            writer.Close()

        End Using

    End Sub

    Public Sub Read()
        Dim hash As New HashSet(Of String)

        Dim xdoc As System.Xml.Linq.XDocument = XDocument.Load("C:\Eric\3.html")
        Dim root = xdoc.Root
        Dim tbody = root.Element("tbody")

        For Each trElement In tbody.Elements()
            Console.WriteLine(trElement.Name)
            Dim tdElements As List(Of XElement) = trElement.Elements().ToList()
            If Not tdElements.Count() = 10 Then
                Continue For
            End If

            'Dim miRNAName = tdElements(0).Value
            Dim geneName = tdElements(1).Value
            If String.IsNullOrWhiteSpace(geneName) Then
                Continue For
            End If

            Dim spanValue = tdElements(3).Element("span").ToString().Replace("<span class=""alignment_form"">", "").Replace("</span>", "")
            Dim splitor() As String = {"<br />"}
            Dim spanItems = spanValue.Split(splitor, StringSplitOptions.RemoveEmptyEntries)
            Dim miRNASequence = spanItems(0).Replace("Query:", "").RemoveDigits().Replace("-", "")
            Dim startAt As Integer = spanItems(2).GetLastNumber()
            'Dim endAt As Integer = spanItems(2).Replace("Sbjct:", "").GetFirstNumber()


            Dim key = miRNASequence + "_" + geneName + "_" + startAt.ToString()
            hash.Add(key)

        Next

        Using sw As New StreamWriter("C:\Eric\result.txt")
            For Each key In hash
                sw.WriteLine(key)
            Next
            sw.Flush()
            sw.Close()

        End Using

    End Sub

End Module
