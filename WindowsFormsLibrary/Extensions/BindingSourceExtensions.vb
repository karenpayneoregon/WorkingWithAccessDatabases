Imports System.Windows.Forms

Namespace Extensions
    ''' <summary>
    ''' To be discussed in part III
    ''' </summary>
    Public Module BindingSourceExtensions
        Public Enum FilterCondition
            StartsWith
            Contains
            EndsWith
        End Enum

        ''' <summary>
        ''' Provides filter for starts-with, contains or ends-with
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <param name="pField">Field to apply filter on</param>
        ''' <param name="pValue">Value for filter</param>
        ''' <param name="pCondition">Type of filter</param>
        ''' <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilter(pSender As BindingSource, pField As String, pValue As String, pCondition As FilterCondition, Optional ByVal pCaseSensitive As Boolean = False)
            Select Case pCondition
                Case FilterCondition.StartsWith
                    pSender.RowFilterStartsWith(pField, pValue.EscapeApostrophe(), pCaseSensitive)
                Case FilterCondition.Contains
                    pSender.RowFilterContains(pField, pValue.EscapeApostrophe(), pCaseSensitive)
                Case FilterCondition.EndsWith
                    pSender.RowFilterEndsWith(pField, pValue.EscapeApostrophe(), pCaseSensitive)
            End Select
        End Sub
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilter(pSender As BindingSource, pField As String, pValue As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'"
        End Sub
        <Runtime.CompilerServices.Extension>
        Public Function RowFilterNewView(pSender As BindingSource, pField As String, pValue As String, Optional ByVal pCaseSensitive As Boolean = False) As DataView
            Dim dt = CType(pSender.DataSource, DataTable)

            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'"

            Dim view As New DataView(dt) With {.RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'"}

            Return view

        End Function
        ''' <summary>
        ''' Build a two field condition
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <param name="pField1"></param>
        ''' <param name="pValue1"></param>
        ''' <param name="pField2"></param>
        ''' <param name="pValue2"></param>
        ''' <param name="pCaseSensitive"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterTwoConditions(pSender As BindingSource, pField1 As String, pValue1 As String, pField2 As String, pValue2 As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField1} = '{pValue1.EscapeApostrophe()}' AND {pField2} = '{pValue2.EscapeApostrophe()}'"
        End Sub
        ''' <summary>
        ''' Apply a filter for Like constraints
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <param name="pField">Field to apply filter on</param>
        ''' <param name="pValue">Value for filter</param>
        ''' <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterContains(pSender As BindingSource, pField As String, pValue As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField} LIKE '%{pValue.EscapeApostrophe()}%'"
        End Sub
        ''' <summary>
        ''' Apply a filter for Like starts with
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <param name="pField">Field to apply filter on</param>
        ''' <param name="pValue">Value for filter</param>
        ''' <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterStartsWith(pSender As BindingSource, pField As String, pValue As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField} LIKE '{pValue.EscapeApostrophe()}%'"
        End Sub
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterEndsWith(pSender As BindingSource, pField As String, pValue As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = $"{pField} LIKE '%{pValue.EscapeApostrophe()}'"
        End Sub
        ''' <summary>
        ''' This extension is a free form method for filtering. The usage would be
        ''' to provide a user interface to put together the condition.  See unit
        ''' test FreeForm_CaseSensitive_OnBoth_Conditions_LastField_NotExact
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <param name="pFilter"></param>
        ''' <param name="pCaseSensitive"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterFreeForm(pSender As BindingSource, pFilter As String, Optional ByVal pCaseSensitive As Boolean = False)
            Dim dt = CType(pSender.DataSource, DataTable)
            dt.CaseSensitive = pCaseSensitive
            dt.DefaultView.RowFilter = pFilter
        End Sub
        ''' <summary>
        ''' Clear DataView RowFilter
        ''' </summary>
        ''' <param name="pSender"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub RowFilterClear(pSender As BindingSource)
            CType(pSender.DataSource, DataTable).DefaultView.RowFilter = ""
        End Sub
        ''' <summary>
        ''' Determine if DataSource is set
        ''' </summary>
        ''' <param name="pSender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function HasData(pSender As BindingSource) As Boolean
            Return pSender.DataSource IsNot Nothing
        End Function


    End Module
End Namespace