Imports System.Web
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Threading


Friend Class Impersonate


#Region "Win32 API Methods"

    Const LOGON32_LOGON_INTERACTIVE As Integer = 2
    Const LOGON32_PROVIDER_DEFAULT As Integer = 0

    Declare Function LogonUserA Lib "advapi32.dll" (ByVal lpszUsername As String, _
                            ByVal lpszDomain As String, _
                            ByVal lpszPassword As String, _
                            ByVal dwLogonType As Integer, _
                            ByVal dwLogonProvider As Integer, _
                            ByRef phToken As IntPtr) As Integer

    Declare Auto Function DuplicateToken Lib "advapi32.dll" ( _
                            ByVal ExistingTokenHandle As IntPtr, _
                            ByVal ImpersonationLevel As Integer, _
                            ByRef DuplicateTokenHandle As IntPtr) As Integer

    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

#End Region


#Region "Default Constructor"

    Private Sub New()
        MyBase.New()
    End Sub

#End Region


#Region "Class Methods"

    ''' <summary>
    ''' Impersonate a user without allowing threads to run under the impersonated user
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <param name="domain"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function ImpersonateValidUser(ByVal userName As String, _
                                                ByVal domain As String,
                                                ByVal password As String) As WindowsImpersonationContext

        Dim impersonationContext As WindowsImpersonationContext = Nothing
        Dim tempWindowsIdentity As WindowsIdentity
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero

        Try

            If RevertToSelf() Then
                If LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, _
                         LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                    If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                        tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                        impersonationContext = tempWindowsIdentity.Impersonate()
                    End If
                End If
            End If
            Return impersonationContext
        Catch ex As Exception
            EventLog.WriteEntry(Application.ProductName, ex.Message)
        Finally
            If Not tokenDuplicate.Equals(IntPtr.Zero) Then
                CloseHandle(tokenDuplicate)
            End If
            If Not token.Equals(IntPtr.Zero) Then
                CloseHandle(token)
            End If
        End Try

        Return Nothing

    End Function


    ''' <summary>
    ''' Impersonate a user and set the thread current principal to that impersonated user.  Afterwards, you can 
    ''' launch threads that will run under the impersonated user.
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <param name="domain"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function ImpersonateValidUserAndSetThreadPrincipal(ByVal userName As String, _
                                                                     ByVal domain As String,
                                                                     ByVal password As String) As WindowsImpersonationContext

        Dim impersonationContext As WindowsImpersonationContext = Nothing
        Dim tempWindowsIdentity As WindowsIdentity
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero
        Dim user As IIdentity
        Dim principal As WindowsPrincipal

        Try

            If RevertToSelf() Then
                If LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, _
                         LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                    If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                        tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                        impersonationContext = tempWindowsIdentity.Impersonate()

                        ' apply impersonation to threading
                        user = New WindowsIdentity(token, "NTLM", WindowsAccountType.Normal, True)
                        principal = New WindowsPrincipal(user)
                        Thread.CurrentPrincipal = principal

                    End If
                End If
            End If
            Return impersonationContext
        Catch ex As Exception
            EventLog.WriteEntry(Application.ProductName, ex.Message)
        Finally
            If Not tokenDuplicate.Equals(IntPtr.Zero) Then
                CloseHandle(tokenDuplicate)
            End If
            If Not token.Equals(IntPtr.Zero) Then
                CloseHandle(token)
            End If
        End Try

        Return Nothing

    End Function


    ''' <summary>
    ''' After calling undo on impersonation, call this method to restore the thread current principal 
    ''' to the logged on user.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub RestoreThreadPrincipal()

        Try
            Dim principal As WindowsPrincipal
            principal = New WindowsPrincipal(WindowsIdentity.GetCurrent)
            Thread.CurrentPrincipal = principal
        Catch ex As Exception
            EventLog.WriteEntry(Application.ProductName, ex.Message)
        End Try

    End Sub


#End Region


End Class



