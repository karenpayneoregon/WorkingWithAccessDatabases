Imports System.Windows.Forms
''' <summary>
''' The height of laziness :-)
''' I tend to place a panel on the form docked to the
''' bottom of the form. So why not create one that does
''' it for me.
''' </summary>
Public Class PanelDockBottom
    Inherits Panel
    Public Sub New()
        Size = New Drawing.Size(1, 48)
        Dock = DockStyle.Bottom
    End Sub
End Class
