Public Class CustomerData
    Public Function CustomerList() As List(Of Customer)
        Dim custList = New List(Of Customer)

        custList.Add(New Customer() With {.CompanyName = "Alfreds Futterkiste", .ContactName = "Maria Anders", .Incorporated = #01/01/2014#, .EstablishedYear = 2012})
        custList.Add(New Customer() With {.CompanyName = "Bon app'", .ContactName = "Laurence Lebihan", .Incorporated = #01/01/2009#, .EstablishedYear = 2013})
        custList.Add(New Customer() With {.CompanyName = "Franchi S.p.A.", .ContactName = "Paolo Accorti", .Incorporated = #01/01/2012#, .EstablishedYear = 2014})
        custList.Add(New Customer() With {.CompanyName = "Split Rail Beer & Ale", .ContactName = "Art Braunschweiger", .Incorporated = #01/01/1999#, .EstablishedYear = 2015})
        custList.Add(New Customer() With {.CompanyName = "Vins et alcools Chevalier", .ContactName = "Paul Henriot", .Incorporated = #01/01/2012#, .EstablishedYear = 2016})

        Return custList

    End Function
End Class
