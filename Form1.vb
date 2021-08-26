Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim arr As New ArrayList

        Dim sales1 As New Sales
        sales1.SalesId = "15121542211"
        sales1.Date = New Date
        sales1.Number = "1001.01/0321/00001"
        arr.Add(sales1)

        Dim sales2 As New Sales
        sales2.SalesId = "654816516561"
        sales2.Date = New Date
        sales2.Number = "1001.01/0321/00002"
        arr.Add(sales2)

        MsgBox(JsonConvert.SerializeObject(arr))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim json = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(txtSumber.Text)
        Dim datas As JArray = JsonConvert.DeserializeObject(Of JArray)(json("data").ToString)

        For i As Integer = 0 To datas.Count - 1
            Dim obj = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(datas(i).ToString)
            'Console.WriteLine("data : " & obj("field_name").ToString)
            'txtHasil.Text = txtHasil.Text & vbCrLf & obj("data").ToString
            Select Case obj("table_name").ToString
                Case "customer"
                    txtHasil.Text = txtHasil.Text & vbCrLf & "Customer id : " & obj("data")("customer_id")
                    txtHasil.Text = txtHasil.Text & vbCrLf & "        name : " & obj("data")("name")
                Case "pos_merk"
                    txtHasil.Text = txtHasil.Text & vbCrLf & "merk id: " & obj("data")("merk_id")
                Case "pos_unit"
                    txtHasil.Text = txtHasil.Text & vbCrLf & "unit id: " & obj("data")("unit_id")
            End Select
        Next
    End Sub
End Class

Class Sales
    Private _salesId As String
    Private _date As Date
    Private _number As String

    Public Property SalesId As String
        Get
            Return _salesId
        End Get
        Set(value As String)
            _salesId = value
        End Set
    End Property

    Public Property [Date] As Date
        Get
            Return _date
        End Get
        Set(value As Date)
            _date = value
        End Set
    End Property

    Public Property Number As String
        Get
            Return _number
        End Get
        Set(value As String)
            _number = value
        End Set
    End Property
End Class