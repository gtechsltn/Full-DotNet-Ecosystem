
Imports ClassLibraryNS20
Imports System

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dBHelper As IDBHelper = New DBHelper()

            'Using Simple Transaction
            dBHelper.InsertCustomer1()

            'Using Transaction Scope
            dBHelper.InsertCustomer2()

            'Using Dapper Transaction
            dBHelper.InsertCustomer3()


    End Sub

End Class
