Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Namespace Classes
    Public Class Category
        Implements INotifyPropertyChanged
        Private _categoryId As Integer
        Private _categoryName As String

        Public Property CategoryID() As Integer
            Get
                Return _categoryId
            End Get
            Set
                _categoryId = Value
                OnPropertyChanged()
            End Set
        End Property

        Public Property CategoryName() As String
            Get
                Return _categoryName
            End Get
            Set
                _categoryName = Value
                OnPropertyChanged()
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return CategoryName
        End Function
        Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged

        Protected Overridable Sub OnPropertyChanged(<CallerMemberName>
        Optional memberName As String = Nothing)

            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))

        End Sub
    End Class
End Namespace