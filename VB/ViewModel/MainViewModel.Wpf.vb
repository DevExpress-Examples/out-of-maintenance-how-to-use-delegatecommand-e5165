Imports DevExpress.Mvvm
Imports System.Windows

Namespace Example.ViewModel

    Public Class MainViewModel
        Inherits ViewModelBase

        Private _AutoUpdateCommand As DelegateCommand, _ManualUpdateCommand As DelegateCommand, _ForceUpdateManualUpdateCommand As DelegateCommand, _CommandWithParameter As DelegateCommand(Of String)

        Public Property AutoUpdateCommand As DelegateCommand
            Get
                Return _AutoUpdateCommand
            End Get

            Private Set(ByVal value As DelegateCommand)
                _AutoUpdateCommand = value
            End Set
        End Property

        Public Property IsAutoUpdateCommandEnabled As Boolean
            Get
                Return GetProperty(Function() Me.IsAutoUpdateCommandEnabled)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() IsAutoUpdateCommandEnabled, value)
            End Set
        End Property

        Private Sub AutoUpdateCommandExecute()
            MessageBox.Show("Hello")
        End Sub

        Private Function AutoUpdateCommandCanExecute() As Boolean
            Return IsAutoUpdateCommandEnabled
        End Function

        Public Property ManualUpdateCommand As DelegateCommand
            Get
                Return _ManualUpdateCommand
            End Get

            Private Set(ByVal value As DelegateCommand)
                _ManualUpdateCommand = value
            End Set
        End Property

        Public Property IsManualUpdateCommandEnabled As Boolean
            Get
                Return GetProperty(Function() Me.IsManualUpdateCommandEnabled)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() IsManualUpdateCommandEnabled, value)
            End Set
        End Property

        Private Sub ManualUpdateCommandExecute()
            MessageBox.Show("Hello")
        End Sub

        Private Function ManualUpdateCommandCanExecute() As Boolean
            Return IsManualUpdateCommandEnabled
        End Function

        Public Property ForceUpdateManualUpdateCommand As DelegateCommand
            Get
                Return _ForceUpdateManualUpdateCommand
            End Get

            Private Set(ByVal value As DelegateCommand)
                _ForceUpdateManualUpdateCommand = value
            End Set
        End Property

        Private Sub ForceUpdateManualUpdateCommandExecute()
            ManualUpdateCommand.RaiseCanExecuteChanged()
        End Sub

        Public Property CommandWithParameter As DelegateCommand(Of String)
            Get
                Return _CommandWithParameter
            End Get

            Private Set(ByVal value As DelegateCommand(Of String))
                _CommandWithParameter = value
            End Set
        End Property

        Private Sub CommandWithParameterExecute(ByVal parameter As String)
            MessageBox.Show(parameter)
        End Sub

        Private Function CommandWithParameterCanExecute(ByVal parameter As String) As Boolean
            Return Not String.IsNullOrEmpty(parameter)
        End Function

        Public Sub New()
            AutoUpdateCommand = New DelegateCommand(AddressOf AutoUpdateCommandExecute, AddressOf AutoUpdateCommandCanExecute)
            ManualUpdateCommand = New DelegateCommand(AddressOf ManualUpdateCommandExecute, AddressOf ManualUpdateCommandCanExecute, False)
            ForceUpdateManualUpdateCommand = New DelegateCommand(AddressOf ForceUpdateManualUpdateCommandExecute)
            CommandWithParameter = New DelegateCommand(Of String)(AddressOf CommandWithParameterExecute, AddressOf CommandWithParameterCanExecute)
        End Sub
    End Class
End Namespace
