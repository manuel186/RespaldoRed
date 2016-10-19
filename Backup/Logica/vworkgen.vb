Public Class vworkgen
    Dim id_workgen, groups_workgen, type_workgen As Integer
    Dim status_workgen, useownaccount_workgen, splitbackup_workgen, usevsc_workgen As Boolean

    Dim typework_workgen, name_workgen, user_workgen, hostname_workgen, ip_workgen As String
    Dim mac_workgen, domain_workgen, username_workgen, password_workgen, fchbackup_workgen As String

    'seeter y getter

    Public Property gid_workgen
        Get
            Return id_workgen
        End Get
        Set(ByVal value)
            id_workgen = value
        End Set
    End Property

    Public Property gstatus_workgen
        Get
            Return status_workgen
        End Get
        Set(ByVal value)
            status_workgen = value
        End Set
    End Property

    Public Property gtypework_workgen
        Get
            Return typework_workgen
        End Get
        Set(ByVal value)
            typework_workgen = value
        End Set
    End Property


    Public Property gname_workgen
        Get
            Return name_workgen

        End Get
        Set(ByVal value)
            name_workgen = value
        End Set
    End Property

    Public Property guser_workgen
        Get
            Return user_workgen
        End Get
        Set(ByVal value)
            user_workgen = value
        End Set
    End Property

    Public Property gtype_workgen
        Get
            Return type_workgen

        End Get
        Set(ByVal value)
            type_workgen = value
        End Set
    End Property



    Public Property ggroups_workgen
        Get
            Return groups_workgen

        End Get
        Set(ByVal value)
            groups_workgen = value
        End Set
    End Property

    Public Property ghostname_workgen
        Get
            Return hostname_workgen

        End Get
        Set(ByVal value)
            hostname_workgen = value
        End Set
    End Property
    Public Property gip_workgen
        Get
            Return ip_workgen

        End Get
        Set(ByVal value)
            ip_workgen = value
        End Set
    End Property

    Public Property gmac_workgen
        Get
            Return mac_workgen

        End Get
        Set(ByVal value)
            mac_workgen = value
        End Set
    End Property


    Public Property guseownaccount_workgen
        Get
            Return useownaccount_workgen

        End Get
        Set(ByVal value)
            useownaccount_workgen = value
        End Set
    End Property


    Public Property gdomain_workgen
        Get
            Return domain_workgen

        End Get
        Set(ByVal value)
            domain_workgen = value
        End Set
    End Property

    Public Property gusername_workgen
        Get
            Return username_workgen

        End Get
        Set(ByVal value)
            username_workgen = value
        End Set
    End Property

    Public Property gpassword_workgen
        Get
            Return password_workgen

        End Get
        Set(ByVal value)
            password_workgen = value
        End Set
    End Property


    Public Property gsplitbackup_workgen
        Get
            Return splitbackup_workgen

        End Get
        Set(ByVal value)
            splitbackup_workgen = value
        End Set
    End Property

    Public Property gusevsc_workgen
        Get
            Return usevsc_workgen

        End Get
        Set(ByVal value)
            usevsc_workgen = value
        End Set
    End Property
    Public Property gfchbackup_workgen
        Get
            Return fchbackup_workgen

        End Get
        Set(ByVal value)
            fchbackup_workgen = value
        End Set
    End Property


    'constructores

    Public Sub New()

    End Sub

    Public Sub New(ByVal id_workgen As Integer, ByVal status_workgen As Boolean, ByVal typework_workgen As String, ByVal name_workgen As String,
                   ByVal user_workgen As String, ByVal type_workgen As Integer, ByVal groups_workgen As Integer,
                   ByVal hostname_workgen As String, ByVal ip_workgen As String, ByVal mac_workgen As String,
                   ByVal useownaccount_workgen As Boolean, ByVal domain_workgen As String, ByVal username_workgen As String,
                   ByVal password_workgen As String, ByVal splitbackup_workgen As Boolean, ByVal usevsc_workgen As Boolean,
                   ByVal fchbackup_workgen As String)
        gid_workgen = id_workgen
        gstatus_workgen = status_workgen
        gtypework_workgen = typework_workgen
        gname_workgen = name_workgen
        guser_workgen = user_workgen
        gtype_workgen = type_workgen
        ggroups_workgen = groups_workgen
        ghostname_workgen = hostname_workgen
        gip_workgen = ip_workgen
        gmac_workgen = mac_workgen
        guseownaccount_workgen = useownaccount_workgen
        gdomain_workgen = domain_workgen
        gusername_workgen = username_workgen
        gpassword_workgen = password_workgen
        gsplitbackup_workgen = splitbackup_workgen
        gusevsc_workgen = usevsc_workgen
        gfchbackup_workgen = fchbackup_workgen
    End Sub



End Class