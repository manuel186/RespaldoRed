Imports System.Threading 'Tuve que trabajar con subprocesos así que importo trabajo con Hilos
Imports System.Xml
Imports Scripting
Imports System.Net
Imports FileCopyExtensions
Imports System.IO
Imports System.Runtime.InteropServices

Imports Microsoft.Win32
Imports System.Security.Principal

Imports System.DirectoryServices


Imports System.Security
Imports System.Security.Permissions
Imports System.Text

Imports System.Net.Sockets


Public Class FRM_Principal
    ''declara variables de WOL
    Public Const MAC_ADDR_BYTES As Integer = 6
    Private Const PORT_BROADCAST = 2304

    Private dt_workgen, dt_workdet As New DataTable

    ''declaracion de variables para login en red
    ''  Private IPers As System.Security.Principal.WindowsImpersonationContext
    '' Private t1 As Thread

    ' DEFINICION DES VARIABLES DE COPIA DE ARCHIVOS
    Dim CopyProgress As CopyFileCallback    ' Eventos para la progresión de copia
    Dim CopyEnd As CopyFileTerminate        ' Eventos para el final de la copia

    '' DEFINE CONFIGURACION
    Public RUTA_SERVIDOR As String
    Public titulo_aplicacion As String
    Public USER_DOMINIO As String

    Public PASSWORD_DOMINIO As String

    Public DOMINIO As String
    Public HOSTNAME As String

    ''variables de configuracin pricipal de dominio
    Public NOMBRE_DOMINIO As String
    Public USUARIO_DOMINIO As String
    Public CLAVE_DOMINIO As String


    Public USER_DOMINIO_peso As String
    Public PASSWORD_DOMINIO_peso As String
    Public DOMINIO_peso As String
    Public HOSTNAME_peso As String

    Public ID_SELECCIONADO As Integer

    Public RESPALDO As String = "DETENIDO"


    Public tipo_respaldo As String = "A" '' identifica si el respaldo es manual o automatico
    Public tipo_respaldo_tarea As String ''identifica si es tarea respaldo incremental, completo.. diferencial..etc. 

    Public divide_backup_por_fecha As Boolean

    Dim Filtro_mascaras2 As String
    Dim Filtro_mascaras As String()

    Dim Filtro_carpeta2 As String
    Dim Filtro_carpeta As String()

    Dim Filtro_mascaras_dir2 As String
    Dim Filtro_mascaras_dir As String()

    Dim var_copia_car As Boolean

    Public XML_ACTUAL As String
    Public ID_ACTUAL As Integer
    Public USUARIO_ACTUAL As String
    Public NOMBRE_DE_TAREA_ACTUAL As String
    Public EQUIPO_ACTUAL As String

    ''define el numero de las columas a usar

    Public COL_ESTADO As Integer
    Public COL_ID As Integer
    Public COL_EQUIPO As Integer
    Public COL_USER As Integer
    Public COL_USUARIO As Integer
    Public COL_GRUPO As Integer

    Public COL_IP_EQUIPO As Integer
    Public COL_TIPO_EQUIPO As Integer
    Public COL_ESTADO_RED As Integer
    Public COL_TAMANO As Integer
    Public COL_ULT_RESPALDO As Integer

    Public ESTADO_TAREA As String


    Public peso_total_archivos_copiado
    Public peso_total_directorios



    Private SUBPping As Thread = Nothing
    Private SUBPRespaldar As Thread = Nothing
    Private SUBPActualiza_Tarea As Thread = Nothing
    Private SUBPLogin As Thread = Nothing

    Private SUBPCalcula_dirs As Thread = Nothing
    Public j As Integer = 0

    ' Private dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()


    ' <remarks>
    ' Constructs and returns a magic packet for the given 
    ' MAC address.
    ' A Magic Packet is 6 bytes of FF followed by the MAC 
    ' address 16 times.
    ' </remarks>
    Public Shared Function GetMagicPacket(ByVal macAddress As String) As Byte()
        Dim Packet As Byte() = New Byte(5 + 16 * MAC_ADDR_BYTES) {} '101 => 102 Elements
        Dim strNumbers As String() = macAddress.Split(New Char() {":", ",", ";", "-"})
        Dim macBytes As Byte() = New Byte(5) {}
        If strNumbers.Length <> 6 Then
            Throw New Exception("MAC Address incorrect!!!")
        End If
        'Convert Numbers to Bytes and set the first 6 FF Values
        For i As Integer = 0 To 5
            Packet(i) = &HFF
            Dim strNumber As String = strNumbers(i)
            'Strip possible leading 0x statments
            If strNumber.StartsWith("0x") Then
                strNumber = strNumber.Substring(2, 2)
            End If
            macBytes(i) = CByte(Int32.Parse(strNumber, System.Globalization.NumberStyles.HexNumber))
        Next i
        'Write the MAC address 16 times after the 6 FF values
        For j As Integer = 0 To 15
            For i As Integer = 0 To 5
                Packet(6 + j * 6 + i) = macBytes(i)
            Next i
        Next j
        Return Packet
    End Function
    '<remarks>
    'Sends the magic packet for a specific MAC address
    '</remarks>
    Public Shared Sub WakeUp(ByVal macAddress As String)
        Dim s As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1)
        Dim Message As Byte() = GetMagicPacket(macAddress)
        Dim IPEP As New IPEndPoint(IPAddress.Broadcast, PORT_BROADCAST)
        s.SendTo(Message, IPEP)
    End Sub




    Private Sub Funcion_ping()
        Dim disponible
        CheckForIllegalCrossThreadCalls = False  'Evitar el error System.InvalidOperationException
        'el error dice que se tuvo acceso al control '' desde un subproceso distinto a aquel en que lo creó

        ''   Dim totalfilas As Integer = DBG_TAREAS.Rows.Count

        disponible = 0
        Try
            For Each row As DataGridViewRow In DBG_TAREAS.Rows
                ' Me.Refresh()
                If My.Computer.Network.IsAvailable() Then
                    If Not (IsNothing(row.Cells(COL_ID).Value)) Then

                        If (row.Cells(COL_ESTADO).Value.ToString = "Activa") Then

                            DBG_TAREAS.ReadOnly = False

                            Dim ip = row.Cells(COL_IP_EQUIPO).Value
                            Dim timeout = 3000
                            Dim sw = New Stopwatch()
                            Try
                                Dim ping As Long = -1
                                sw.Start()
                                If My.Computer.Network.Ping(ip, timeout) Then
                                    sw.Stop()
                                    ping = sw.ElapsedMilliseconds
                                    ''    Label1.Text = String.Format("{0}ms", ping)
                                End If
                                If ping < 0 Then
                                    row.Cells(COL_ESTADO_RED).Value = "OFFLINE"
                                    ''' Label2.Text = "Ping Timed Out"
                                    '' Label3.BackColor = Color.Brown
                                ElseIf ping < 200 Then
                                    row.Cells(COL_ESTADO_RED).Value = "Online"
                                    ''  Label2.Text = "Good Connection"
                                    '' Label3.BackColor = Color.Green
                                ElseIf ping < 400 Then
                                    row.Cells(COL_ESTADO_RED).Value = "Online"
                                    ''  LB_DOMINIO.Text = "Medium Connection"
                                    '' Label3.BackColor = Color.Orange
                                Else
                                    row.Cells(COL_ESTADO_RED).Value = "OFFLINE"
                                    ''   Label2.Text = "Bad Connection"
                                    ''  Label3.BackColor = Color.Red
                                End If
                            Catch ex As Exception
                                ''  Label2.Text = ""
                                '' Label1.Text = ex.Message
                                ''   Label3.BackColor = Color.Red

                            End Try


                            If (row.Cells(COL_ESTADO_RED).Value = "Online") And (row.Cells(COL_ULT_RESPALDO).Value > 0) Then
                                disponible = 1
                                ''  BT_PLAY.PerformClick()

                            End If


                            DBG_TAREAS.ReadOnly = True
                            ''  DBG_Estado.AllowUserToAddRows = False
                        End If

                    End If

                Else
                    Dim response
                    response = MsgBox("Revise su conexion a internet y presiones aceptar para continuar", vbYesNo, titulo_aplicacion)

                    If response = vbYes Then

                    End If

                End If




                Try
                    DBG_TAREAS.Sort(DBG_TAREAS.Columns(COL_ESTADO_RED), System.ComponentModel.ListSortDirection.Ascending)
                    DBG_TAREAS.Sort(DBG_TAREAS.Columns(COL_ULT_RESPALDO), System.ComponentModel.ListSortDirection.Descending)
                Catch ex As Exception

                End Try


            Next

            If (disponible = 1) And (RESPALDO = "DETENIDO") Then
                inicia_respaldo()
            End If
            ''  


        Catch ex As Exception
            '' MsgBox(ex)
        End Try


    End Sub

    Private Sub ThreadTask()
        ''para el login en red 
        Dim counter As Integer = 0
        Dim endVal As Integer = 3

        ' unending loop to represent long running task
        Do Until counter = endVal
            If counter = (endVal - 1) Then
                counter = 0
            Else
                counter += 1
            End If
        Loop
    End Sub

    Private Sub calcula_peso_directorio(ByVal info_origen, ByVal sw)
        Dim peso_arch_origen As Long = (info_origen.Length)

        If sw = 1 Then

            peso_total_directorios = peso_total_directorios + peso_arch_origen  'tranforma de bytes a kb y luego a mb dividir *1024
        Else
            peso_total_directorios = peso_total_directorios + 0
        End If

    End Sub




    Private Sub Funcion_Respaldar()
        Dim Impersonator As New clsAuthenticator

        RESPALDO = "INICIADO"

        peso_total_archivos_copiado = 0
        Dim login As Boolean

        CheckForIllegalCrossThreadCalls = False  'Evitar el error System.InvalidOperationException
        'el error dice que se tuvo acceso al control '' desde un subproceso distinto a aquel en que lo creó

        Dim largo As String
        Dim var As String
        ''    Dim totalfilas As Integer = DBG_TAREAS.Rows.Count
        Dim documetoXML As XmlDocument
        Dim destino As String
        Dim nodelist As XmlNodeList
        Dim nodelist2 As XmlNodeList
        Dim nodelist3 As XmlNodeList
        Dim nodo As XmlNode
        Dim nodo2 As XmlNode
        Dim nodo3 As XmlNode

        Dim j5, i3 As Integer
        Dim j6 As Integer
        '' Dim ID


        tipo_respaldo_tarea = ""


        Dim j As Integer = 0
        ''  For j = 0 To totalfilas - 2


        For Each row As DataGridViewRow In DBG_TAREAS.Rows

            If Not (IsNothing(row.Cells(COL_ID).Value)) Then

                Try
                    If tipo_respaldo = "M" Then
                        Dim dila As Integer
                        dila = DBG_TAREAS.CurrentCell.RowIndex

                        Dim campo = row.Cells(COL_ID).Value
                        If Not (String.IsNullOrEmpty(campo)) Then
                            ID_ACTUAL = DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
                            USUARIO_ACTUAL = DBG_TAREAS(COL_USER, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
                            EQUIPO_ACTUAL = DBG_TAREAS(COL_EQUIPO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
                            NOMBRE_DE_TAREA_ACTUAL = DBG_TAREAS(COL_USUARIO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
                            '' busca_usuario(ID_ACTUAL)
                        End If
                        j = DBG_TAREAS.CurrentCell.RowIndex


                    End If

                    If tipo_respaldo = "A" Then
                        Dim campo = row.Cells(COL_ID).Value
                        If Not (String.IsNullOrEmpty(campo)) Then
                            ID_ACTUAL = row.Cells(COL_ID).Value.ToString
                            USUARIO_ACTUAL = row.Cells(COL_USER).Value.ToString
                            EQUIPO_ACTUAL = row.Cells(COL_EQUIPO).Value.ToString
                            NOMBRE_DE_TAREA_ACTUAL = row.Cells(COL_USUARIO).Value.ToString
                        End If


                    End If


                    ''  Me.Refresh()
                    If My.Computer.Network.IsAvailable() Then
                        Try
                            If Not (String.IsNullOrEmpty(ID_ACTUAL)) Then

                                If row.Cells(COL_ID).Value = ID_ACTUAL Then


                                    If (row.Cells(COL_ESTADO).Value.ToString = "Activa") And (row.Cells(COL_ESTADO_RED).Value.ToString = "Online") And ((row.Cells(COL_ULT_RESPALDO).Value.ToString) > 0) Then
                                        row.Cells(COL_ESTADO).Value = "Respaldando"

                                        ''  DBG_TAREAS.CurrentRow.DefaultCellStyle.BackColor = Color.Blue

                                        Dim dts As New vworkgen
                                        Dim funcID As New fworkgen
                                        funcID.ver_workgen_by_id(dts, ID_ACTUAL)
                                        '' 
                                        tipo_respaldo_tarea = dts.gtypework_workgen
                                        divide_backup_por_fecha = dts.gsplitbackup_workgen

                                        Dim funcDest As New fworkgen
                                        Dim TablaDest As New DataTable
                                        TablaDest = funcDest.carga_destinations(ID_ACTUAL)

                                        destino = TablaDest.Rows(0).Item(3).ToString

                                        Dim useownaccount, USEREQUIPO


                                        useownaccount = dts.guseownaccount_workgen
                                        USEREQUIPO = dts.guser_workgen
                                        HOSTNAME = dts.ghostname_workgen
                                        DOMINIO = dts.gdomain_workgen


                                        If useownaccount = True Then
                                            '' SI NO USA una cuenta propia para su ejecucion
                                            USER_DOMINIO = dts.gusername_workgen
                                            Dim des As New EncriptarDesencriptar
                                            PASSWORD_DOMINIO = des.desencriptar128BitRijndael(dts.gpassword_workgen, DOMINIO + "\" + USEREQUIPO)
                                        Else
                                            ''SI USA CLAVE DE DOMINIO
                                            USER_DOMINIO = USUARIO_DOMINIO
                                            PASSWORD_DOMINIO = CLAVE_DOMINIO
                                        End If



                                        login = False

                                        Try
                                            LB_log.Items.Add("Iniciando sesión como " + USER_DOMINIO + " en equipo " & HOSTNAME)


                                            '  IPers = Impersonate.ImpersonateValidUserAndSetThreadPrincipal(USER_DOMINIO, DOMINIO, PASSWORD_DOMINIO)
                                            '  t1 = New Thread(AddressOf ThreadTask)
                                            '  t1.IsBackground = True
                                            '  t1.Start()



                                            Impersonator.Impersonator(DOMINIO, USER_DOMINIO, PASSWORD_DOMINIO)


                                            login = True
                                        Catch ex As Exception
                                            login = False
                                            LB_log.Items.Add("Error de inicio de sesión" & ex.ToString)

                                        End Try


                                        If login Then
                                            LB_log.Items.Add("Sesión iniciada correctamente en equipo " & HOSTNAME)

                                            Filtro_mascaras2 = lee_xml_filter_mascara(ID_ACTUAL)
                                            Filtro_carpeta2 = lee_xml_filter_carpeta(ID_ACTUAL)


                                            Dim funcDET As New fworkgen
                                            Dim TablaDeT As New DataTable
                                            TablaDeT = funcDET.carga_sources(ID_ACTUAL)

                                            Dim i, total
                                            total = TablaDeT.Rows.Count - 1


                                            For i = 0 To total Step 1
                                                LB_log.Items.Add("Comenzando Copia de Archivos")

                                                Dim carpeta As String = devuelte_ultima_carpeta(TablaDeT.Rows(i).Item(3).ToString)

                                                If divide_backup_por_fecha = True Then
                                                    carpeta = Format(Now(), "dd-MM-yyyy") & "/" & carpeta
                                                End If

                                                Dim diSource As New DirectoryInfo(TablaDeT.Rows(i).Item(3).ToString)
                                                Dim diDestiny As New DirectoryInfo(destino & "\" & carpeta)
                                                RecursiveCopyFiles(diSource, diDestiny, True)

                                            Next


                                            '' Impersonator.Undo()

                                            ''cierra el hilo de login
                                            '   If Not IPers Is Nothing Then
                                            ' undo impersonation at the level of the current windows identity
                                            '  IPers.Undo()
                                            ' removes prior thread impersonation by setting it back to the 
                                            ' current windows identity
                                            '   Impersonate.RestoreThreadPrincipal()
                                            ' End If


                                            ''    LB_log.Items.Clear()

                                            busca_y_cambia_estado_a_activo(ID_ACTUAL) ''cambia el estado a activo

                                            ToolStripStatusLabel1.Text = ""

                                            ''  If peso_total_archivos_copiado > 0 Then

                                            cambia_a_0_ultimo_respaldo(ID_ACTUAL) '''cuando el respaldo se completa cambia a 0 el ultimo respaldo

                                            inserta_backupinfo(ID_ACTUAL, tipo_respaldo_tarea, peso_total_archivos_copiado)


                                            ''  lee_xml_det(XML_ACTUAL, ID_ACTUAL) ''el 0 lee detalle  
                                            j = 0


                                            ''Else
                                            ''  MsgBox("Ok " & "Se ha terminado de respaldar la tarea del usuario " & USUARIO_ACTUAL & " en el equipo  " & EQUIPO_ACTUAL & " con  0  de peso copiado ")
                                            '' LB_log.Items.Add("Se ha terminado de respaldar la tarea del usuario " & USUARIO_ACTUAL & " en el equipo  " & EQUIPO_ACTUAL & " con 0  de peso copiado ")

                                            ''  End If


                                            LB_log.SelectedIndex = LB_log.Items.Count - 1
                                            tipo_respaldo = "A" '' vuelve a setear el estado a automatico


                                            '''falta que muestre el detalle del click


                                        Else
                                            '' LB_log.Items.Add("Error al iniciad Sesión como " + " Administrador " + " en equipo " & DBG_TAREAS(COL_EQUIPO, DBG_TAREAS.CurrentRow.Index).Value.ToString())

                                        End If


                                        ' DBG_Estado.CurrentCell = DBG_Estado(0, j)  ' mueve el cursor a la celda siguiente


                                    End If


                                End If
                            End If
                            '' cambiar a (ex.Message) para ver el el mensaje corto
                            ' code
                        Catch ax As UnauthorizedAccessException
                            '' MsgBox("ax: " & ax.ToString)
                            LB_log.Items.Add("AX " & ax.Message)
                            LB_log.SelectedIndex = LB_log.Items.Count - 1
                        Catch ix As IO.IOException
                            ''MsgBox("ix: " & ix.ToString)
                            LB_log.Items.Add("IX " & ix.Message)
                            LB_log.SelectedIndex = LB_log.Items.Count - 1
                        Catch ex As Exception
                            ''  MsgBox("ex2: " & ex.ToString)
                            LB_log.Items.Add("EX " & ex.Message)
                            LB_log.SelectedIndex = LB_log.Items.Count - 1
                        End Try


                    Else
                        LB_log.Items.Add("Problema de red revise su conexion a internet")
                        busca_y_cambia_estado_a_activo(ID_ACTUAL)
                        RESPALDO = "DETENIDO"

                        '' MsgBox("")
                    End If

                Catch ex As Exception
                End Try

            End If
        Next



        If Me.SUBPRespaldar.ThreadState = Threading.ThreadState.Running Then
            BT_PLAY.Enabled = True
            BT_STOP.Enabled = False
            LB_log.Items.Add("Se ha terminado de leer las tareas, no hay tareas activas pendientes sin respaldo ")
            LB_log.SelectedIndex = LB_log.Items.Count - 1
            RESPALDO = "DETENIDO"
            Me.SUBPRespaldar.Abort()

        End If

    End Sub




    Private Sub RecursiveCopyFiles(ByVal sourceDir As DirectoryInfo, ByVal destDir As DirectoryInfo, ByVal blOverwrite As Boolean)
        Dim info_origen As System.IO.FileInfo  ' obtiene propiedades del archivo de origen
        Dim info_destino As System.IO.FileInfo ' obtiene propiedades del archivo de destino
        Dim ver_dir_doctos As Boolean
        var_copia_car = True
        Dim diSourceSubDirectories() As DirectoryInfo
        Dim fiSourceFiles() As FileInfo

        'obtengo todos los archivos del directorio origen
        fiSourceFiles = sourceDir.GetFiles()
        'obtengo los subdirectorios (si existen)
        diSourceSubDirectories = sourceDir.GetDirectories()

        '' si es la carpeta mis documentos cambia las ruta de copia de archivos
        Dim carpeta2 As String = devuelte_ultima_carpeta(sourceDir.FullName)
        If carpeta2 = "Documents" Then
            Dim rutaacambiarr As String
            rutaacambiarr = devuelte_ruta__sin_ultima_carpeta(sourceDir.FullName)
            For i5 = 0 To diSourceSubDirectories.Length - 1
                If diSourceSubDirectories(i5).Name = New String("Mi música") Then
                    diSourceSubDirectories(i5) = New DirectoryInfo((New String(rutaacambiarr + "\Music")))
                End If
                If diSourceSubDirectories(i5).Name = New String("Mis imágenes") Then   ''Replace("Documents\Mi imágenes", "Pictures")))
                    diSourceSubDirectories(i5) = New DirectoryInfo((New String(rutaacambiarr + "\Pictures")))
                End If
                If diSourceSubDirectories(i5).Name = New String("Mis vídeos") Then
                    diSourceSubDirectories(i5) = New DirectoryInfo((New String(rutaacambiarr + "\Videos")))
                End If
            Next
        End If



        'busca los filtros de mascaras
        If Not (IsNothing(Filtro_mascaras2)) Then
            Filtro_mascaras = Filtro_mascaras2.Split(New Char() {";"c})
        End If


        var_copia_car = True

        'busca los filtros de carpetas
        If Not (IsNothing(Filtro_carpeta2)) Then
            Filtro_carpeta = Filtro_carpeta2.Split(New Char() {";"c})

            Dim largoo As Integer
            Dim largo22 As Integer

            Dim i3, i6 As Integer

            Dim carpeta_new As String
            'Si la carpeta esta dentro de la lista no autoriza copia
            i3 = 0
            For i3 = 0 To Filtro_carpeta.Length - 1 Step 1
                largo22 = Filtro_carpeta(i3).Length - 1
                If largo22 = -1 Then
                    i3 = i3 + 1
                Else
                    carpeta_new = Filtro_carpeta(i3).ToString
                    If (sourceDir.FullName = carpeta_new) Then
                        var_copia_car = False
                    End If

                End If
            Next
        End If


        If var_copia_car = True Then  '' accede a la copia de la carpeta

            'si no existe el directorio destino lo crear
            If Not destDir.Exists Then
                destDir.Create()

                Dim carpeta3 As String = devuelte_ultima_carpeta(destDir.FullName)
                If carpeta3 = "Documents" Then
                    tipo_respaldo_tarea = "Completo"

                End If
            End If
            'Usar la recursividad para navegar por los subdirectorios
            'e ir obteniendo los archivos hasta llegar al final
            For Each diSourceSubDirectory As DirectoryInfo In diSourceSubDirectories
                LB_log.Items.Add("Abriendo carpeta " & sourceDir.FullName & "\" & diSourceSubDirectory.Name)
                RecursiveCopyFiles(New DirectoryInfo(diSourceSubDirectory.FullName), New DirectoryInfo(destDir.FullName & "\" & diSourceSubDirectory.Name), blOverwrite)

            Next

            ''copiar archivos
            For Each fiSourceFile As FileInfo In fiSourceFiles
                Try
                    info_origen = New FileInfo(sourceDir.FullName & "\" & fiSourceFile.Name) ''fiSourceFile
                    info_destino = New FileInfo(destDir.FullName & "\" & fiSourceFile.Name)
                    ' peso_arch_origen = ((info_origen.Length / 1024) / 1024)   'tranforma de bytes a kb y luego a mb

                    Dim largo As Integer
                    Dim largo2 As Integer
                    Dim filtro As String
                    Dim i2 As Integer
                    Dim var_copia_arc As Boolean
                    Dim extencion_new As String
                    Dim fecha_info_destino As String
                    Dim fecha_info_origen As String
                    Dim extencion_arch_origen As String


                    extencion_arch_origen = info_origen.Extension.ToString().ToLower()

                    var_copia_arc = True

                    'Si extencion de archivo no esta dentro de la lista de filtro copia el archivo
                    If Not (IsNothing(Filtro_mascaras2)) Then
                        i2 = 0
                        For i2 = 0 To Filtro_mascaras.Length - 1 Step 1
                            largo2 = Filtro_mascaras(i2).Length - 1
                            If largo2 = -1 Then
                                i2 = i2 + 1
                            Else
                                extencion_new = Filtro_mascaras(i2).Substring(1, largo2)
                                If (extencion_arch_origen = extencion_new) Then
                                    var_copia_arc = False
                                End If

                            End If
                        Next
                    Else
                        var_copia_arc = True
                    End If

                    If var_copia_arc = True Then
                        fecha_info_destino = info_destino.LastWriteTime.Date.ToShortDateString()
                        fecha_info_origen = info_origen.LastWriteTime.Date.ToShortDateString()

                        Select Case tipo_respaldo_tarea
                            Case "Completo"
                                'MsgBox("Fichero no existe se copiará fichero nuevo")
                                ToolStripStatusLabel1.Text = "Copiando " + (New String(destDir.FullName & "\" & fiSourceFile.Name))
                                LB_log.Focus()
                                LB_log.Items.Add("Copiando  " + (New String(destDir.FullName & "\" & fiSourceFile.Name)))
                                calcula_peso_copiado(info_origen, 1)
                                copiar(info_origen, info_destino)

                            Case "Incremental"
                                ' si existe el archivo compara con el origen y si es diferente lo copia
                                If (My.Computer.FileSystem.FileExists(New String(destDir.FullName & "\" & fiSourceFile.Name))) Then


                                    ' MsgBox("Fecha no es igual listo para copiar archivo")
                                    If Not (CDate(fecha_info_origen) = CDate(fecha_info_destino)) Then
                                        calcula_peso_copiado(info_origen, 1)

                                        copiar(info_origen, info_destino)
                                        ToolStripStatusLabel1.Text = "Copiando " + (New String(destDir.FullName & "\" & fiSourceFile.Name))

                                        LB_log.Items.Add("Copiando  " + (New String(destDir.FullName & "\" & fiSourceFile.Name)))
                                    Else
                                        calcula_peso_copiado(info_origen, 0)
                                        ToolStripStatusLabel1.Text = "Copiando " + (New String(destDir.FullName & "\" & fiSourceFile.Name))
                                        LB_log.Focus()
                                        LB_log.Items.Add("Copiando  " + (New String(destDir.FullName & "\" & fiSourceFile.Name)))
                                    End If
                                Else

                                    'MsgBox("Fichero no existe se copiará fichero nuevo")
                                    ToolStripStatusLabel1.Text = "Copiando " + (New String(destDir.FullName & "\" & fiSourceFile.Name))
                                    LB_log.Focus()
                                    LB_log.Items.Add("Copiando  " + (New String(destDir.FullName & "\" & fiSourceFile.Name)))
                                    calcula_peso_copiado(info_origen, 1)
                                    copiar(info_origen, info_destino)

                                End If


                        End Select



                    End If

                    LB_log.SelectedIndex = LB_log.Items.Count - 1

                Catch ex As Exception
                    LB_log.Items.Add("Error: " & ex.Message)

                End Try
            Next

        End If




    End Sub

    Private Function devuelte_ruta__sin_ultima_carpeta(ByVal ruta)
        Dim strTest, carpeta As String
        Dim strArray() As String
        Dim intCount As Integer

        strTest = ruta
        strArray = Split(strTest, "\")

        For intCount = LBound(strArray) To UBound(strArray) - 1
            If Trim(strArray(intCount)) <> "" Then
                carpeta = carpeta + "\" + Trim(strArray(intCount))
            End If

        Next

        Return "\" + carpeta

    End Function

    Private Function devuelte_ultima_carpeta(ByVal ruta)
        Dim strTest, carpeta As String
        Dim strArray() As String
        Dim intCount As Integer

        strTest = ruta
        strArray = Split(strTest, "\")

        For intCount = LBound(strArray) To UBound(strArray)
            If Trim(strArray(intCount)) <> "" Then
                carpeta = Trim(strArray(intCount))
            End If

        Next

        Return carpeta

    End Function


    Private Sub calcula_peso_copiado(ByVal info_origen, ByVal sw)
        Dim peso_arch_origen As Long = (info_origen.Length)   'tranforma de bytes a kb y luego a mb

        ''si es 1 esta copiando el archivo si es 0 no guarda el peso del archivo
        If sw = 1 Then
            peso_total_archivos_copiado = peso_total_archivos_copiado + peso_arch_origen
        Else
            peso_total_archivos_copiado = peso_total_archivos_copiado + 0
        End If

    End Sub



    Private Sub copiar(ByVal info_origen, ByVal info_destino)
        Dim archivo
        archivo = info_origen
        ProgressBar_archivo.Visible = True
        ProgressBar_archivo.Maximum = info_origen.Length



        CopyProgress = New CopyFileCallback(AddressOf State_CopyProgress)
        CopyEnd = New CopyFileTerminate(AddressOf Exemple_CopyEnd)
        Try
            ' ListBox1.Items.Add("Copiaando  " & archivo)
            FileCopyExtensions.FileCopyExtensions.CopyFile(info_origen, info_destino, CopyFileOptions.All, CopyProgress, CopyEnd)
        Catch ex As Exception
            ToolStripStatusLabel1.Text = "Error al Copiar " + info_origen
        End Try


    End Sub





    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim aplicacioncorriendo As Process() = Process.GetProcessesByName("Backup")

        If aplicacioncorriendo.Length > 1 Then
            ''si la aplicacion se encuentra funcionando y se abre por segunda vez la cierra.

            '''MessageBox.Show("la aplciacion se esta ejecutando")
            Me.Close()
        End If


        



        Me.KeyPreview = True

        BT_STOP.Enabled = False
        Me.ProgressBar_archivo.Visible = False
        'Me.ProgressBar_archivo.Scrolling = ccScrollingSmooth

        Me.Text = titulo_aplicacion
        NotifyIcon1.Text = titulo_aplicacion
        ToolStripMenu_Abrir.Text = "Minimizar"

        ' carga icono
        Dim testFile As System.IO.FileInfo
        testFile = My.Computer.FileSystem.GetFileInfo("icono.ico")
        Dim folderPath As String = testFile.DirectoryName
        'MsgBox(folderPath)
        Dim fileName As String = testFile.Name
        'MsgBox(fileName)

        Dim fullPath As String
        fullPath = My.Computer.FileSystem.CombinePath(folderPath, fileName)
        ' MsgBox(fullPath)

        If My.Computer.FileSystem.FileExists(fullPath) Then
            NotifyIcon1.Icon = New System.Drawing.Icon(fullPath)
        Else
            '.msg_box("El icono de software no se encientr", estilo_msgbox_informacion, titulo_aplicacion)

        End If
        ''''''
        Me.WindowState = FormWindowState.Maximized

        Dim classResize As New clsResizeForm
        classResize.ResizeForm(Me, 1336, 768)  ''1366




        Dim dts As New vworkgen
        Dim func As New fworkgen

        dt_workgen.Clear()
        dt_workgen = func.mostrar_workgen()

        If dt_workgen.Rows.Count <> 0 Then
            DBG_TAREAS.DataSource = dt_workgen

            abre_detalle_de_item_seleccionado(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString())

        Else
            DBG_TAREAS.DataSource = Nothing
            abre_detalle_de_item_seleccionado(0)
        End If


        DBG_TAREAS.Columns(0).Width = 80 ''estado
        DBG_TAREAS.Columns(1).Width = 40  ''Id
        DBG_TAREAS.Columns(2).Width = 100 ''equipo
        DBG_TAREAS.Columns(3).Width = 100 ''user
        DBG_TAREAS.Columns(4).Width = 180 ''usuario
        DBG_TAREAS.Columns(5).Width = 100 ''grupo
        DBG_TAREAS.Columns(6).Width = 95 '' ip
        DBG_TAREAS.Columns(7).Width = 40 '' tipo
        DBG_TAREAS.Columns(8).Width = 70 ''estado en red
        DBG_TAREAS.Columns(9).Width = 70 ''tamaña
        DBG_TAREAS.Columns(10).Width = 70 '' ultimo resp

        DBG_TAREAS.RowHeadersVisible = False  ''elimina la primera columna

        Dim totalfilasgrilla As Integer = DBG_TAREAS.Columns.Count - 1
        Dim m As Integer = 0


        For m = 0 To totalfilasgrilla Step 1
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Estado")) Then
                COL_ESTADO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "ID")) Then
                COL_ID = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Equipo")) Then
                COL_EQUIPO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "User PC")) Then
                COL_USER = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Usuario")) Then
                COL_USUARIO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Grupo")) Then
                COL_GRUPO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "IP")) Then
                COL_IP_EQUIPO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Tipo")) Then
                COL_TIPO_EQUIPO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Estado en Red")) Then
                COL_ESTADO_RED = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Tamaño")) Then
                COL_TAMANO = m
            End If
            If ((Me.DBG_TAREAS.Columns(m).Name.ToString() = "Respaldo")) Then
                COL_ULT_RESPALDO = m
            End If

        Next
        ''





        ''una vez cargado los datos de sistema inicia la busqueda de equipos disponibles
        RESPALDO = "DETENIDO"
        Me.SUBPping = New Threading.Thread(AddressOf Me.Funcion_ping)
        If Me.SUBPping.ThreadState <> Threading.ThreadState.Running Then
            Me.SUBPping.Start()
        End If

    End Sub

    Private Sub abre_detalle_de_item_seleccionado(ID As Integer)
        DBG_Det.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DBG_Det.RowHeadersVisible = False  ''elimina la primera columna

        Dim dts As New vworkgen
        Dim func As New fworkgen

        dt_workdet.Clear()
        dt_workdet = func.mostrar_workdet(ID)

        If dt_workdet.Rows.Count <> 0 Then
            DBG_Det.DataSource = dt_workdet

            DBG_Det.Columns(0).Width = 80 ''tiepo de respald
            DBG_Det.Columns(1).Width = 120 '' fecha
            DBG_Det.Columns(2).Width = 70 '' tamañp
            DBG_Det.Columns(3).Width = 50 '' ID
        Else

            DBG_Det.DataSource = Nothing

        End If
    End Sub

    Private Function lee_xml_filter_mascara(ByVal ID_ACTUAL)

        Dim j As Integer

        Dim funcFILMAS As New fworkgen
        Dim TablaFILMAS As New DataTable
        TablaFILMAS = funcFILMAS.mostrar_filtros_mascaras(ID_ACTUAL)

        Dim retorno As String = ""
        If TablaFILMAS.Rows.Count > 0 Then


            Dim i, total
            total = TablaFILMAS.Rows.Count - 1

            Dim Filtro_mascaras(total) As String

            j = 0
            For i = 0 To total Step 1

                Filtro_mascaras(j) = TablaFILMAS.Rows(i).Item(0).ToString

                j = j + 1
            Next

            retorno = Join(Filtro_mascaras, ";")
        Else
            retorno = ""
        End If


        Return retorno
    End Function

    Private Function lee_xml_filter_carpeta(ByVal ID_ACTUAL)

        Dim j As Integer

        Dim funcFILMAS As New fworkgen
        Dim TablaFILMAS As New DataTable
        TablaFILMAS = funcFILMAS.mostrar_filtros_carpeta(ID_ACTUAL)
        Dim retorno As String = ""
        If TablaFILMAS.Rows.Count > 0 Then
            Dim i, total
            total = TablaFILMAS.Rows.Count - 1

            Dim Filtro_carpeta(total) As String

            j = 0
            For i = 0 To total Step 1

                Filtro_carpeta(j) = TablaFILMAS.Rows(i).Item(0).ToString

                j = j + 1
            Next

            retorno = Join(Filtro_carpeta, ";")
        Else
            retorno = ""
        End If


        Return retorno
    End Function







    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim filespec As String = "C:\wamp"
        Dim fso, f, s

        fso = CreateObject("Scripting.FileSystemObject")
        f = fso.Getfolder(filespec)
        's = "Tamaño: " & (CInt(f.size) / 1024)
        s = "Tamaño: " & ((((f.size) / 1024) / 1024) / 1024)

        MessageBox.Show("tamaño del directori wamp " & s & " Gb")

    End Sub








    Private Sub ToolStripMenu_Abrir_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenu_Abrir.DoubleClick

        NotifyIcon1.Visible = False 'oculta el icono en la Tray Bar
        Me.Visible = True           'vuelve visible el Form de la aplicación
        ToolStripMenu_Abrir.Text = "Minimizar"

    End Sub




    Private Function State_CopyProgress(ByVal source As FileInfo, ByVal destination As FileInfo, ByVal state As Object, ByVal totalFileSize As Long, ByVal totalBytesTransferred As Long) As CopyFileCallbackAction
        ' Código Quiero realizar ( actualizar una barra de progreso , etc. )
        CheckForIllegalCrossThreadCalls = False  'Evitar el error System.InvalidOperationException
        'el error dice que se tuvo acceso al control '' desde un subproceso distinto a aquel en que lo creó
        Try

            If totalBytesTransferred > ProgressBar_archivo.Maximum Then
                ProgressBar_archivo.Value = ProgressBar_archivo.Maximum
            Else
                ProgressBar_archivo.Value = totalBytesTransferred
            End If


        Catch ex As Exception

        End Try

        Return CopyFileCallbackAction.Continue
        ' A continuación, el valor de retorno , continuamos o no copiar

    End Function


    Private Sub Exemple_CopyEnd(ByVal succes As Boolean)
        ' Código que hice al final de la copia (mensaje, etc. )
        '...
        ProgressBar_archivo.Value = 0
    End Sub


    Private Sub inserta_backupinfo(ByVal ID As String, ByVal tipo_respaldo As String, ByVal tamaño As Double)

        Dim correl As Integer
        Dim tamaño_ok As String

        Dim func As New fworkgen

        correl = func.ver_correl_workdet(ID)

        If tamaño = 0 Then
            tamaño_ok = 0 & " bytes "

        End If

        If (tamaño / 1024) > 1 Then
            tamaño_ok = FormatNumber((tamaño / 1024), 2) & " KB "

        End If

        If ((tamaño / 1024) / 1024) > 1 Then
            tamaño_ok = FormatNumber(((tamaño / 1024) / 1024), 2) & " MB "

        End If

        If (((tamaño / 1024) / 1024) / 1024) > 1 Then
            tamaño_ok = FormatNumber((((tamaño / 1024) / 1024) / 1024), 2) & " GB "
        End If



        Dim funcDET As New fworkgen
        If funcDET.inserta_workdet(ID, correl, tipo_respaldo, tamaño_ok) Then

            ''recorre la grilla y abre el detalle de la recien terminada tarea
            Dim i2 As Integer = 0
            For Each row2 As DataGridViewRow In DBG_TAREAS.Rows

                Dim campo = row2.Cells(1).Value
                If (Not (String.IsNullOrEmpty(campo)) And campo = ID) Then
                    ''  selecciona la fila correpondiente a la tarea y muestra el detalle
                    DBG_TAREAS.CurrentCell = DBG_TAREAS.Rows(i2).Cells(0)
                    abre_detalle_de_item_seleccionado(ID_ACTUAL)
                End If
                i2 = +1

            Next

            LB_log.Items.Add("Se ha terminado de respaldar la tarea del usuario " & USUARIO_ACTUAL & " en el equipo  " & EQUIPO_ACTUAL & " con " & tamaño_ok & " de peso copiado ")
        Else
            LB_log.Items.Add("Error al insertar datos en tabla de detalle del usuario " & USUARIO_ACTUAL & " en el equipo  " & EQUIPO_ACTUAL & " con " & tamaño_ok & " de peso copiado ")

        End If






    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ToolStripMenu_Abrir.Text = "Minimizar"
        'NotifyIcon1.Visible = False 'oculta el icono en la Tray Bar
        NotifyIcon1.Visible = True 'vuelve visible el icono en la Tray Bar
        Me.Visible = True           'vuelve visible el Form de la aplicación
    End Sub



    Private Sub EjecutarTareaAhoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EjecutarTareaAhoraToolStripMenuItem.Click
        tipo_respaldo = "M"
        inicia_respaldo()
    End Sub

    Private Sub inicia_respaldo()
        RESPALDO = "INICIADO"

        Me.SUBPRespaldar = New Threading.Thread(AddressOf Me.Funcion_Respaldar)
        If Me.SUBPRespaldar.ThreadState <> Threading.ThreadState.Running Then
            Me.SUBPRespaldar.Start()
            LB_log.Items.Add("Se ha inciado el proceso respaldo  ")
            BT_PLAY.Enabled = False
            BT_PAUSE.Enabled = True
            BT_STOP.Enabled = True
        End If


    End Sub

    Private Sub BT_PLAY_Click(sender As Object, e As EventArgs) Handles BT_PLAY.Click
        BT_PAUSE.Enabled = True
        BT_STOP.Enabled = True

        If RESPALDO = "PAUSADO" Then
            If Me.SUBPRespaldar.ThreadState = Threading.ThreadState.Suspended Then
                Me.SUBPRespaldar.Resume()
                RESPALDO = "INICIADO"
                LB_log.Items.Add("Se ha reiniciado el proceso de copia de la tarea  ")
                BT_PAUSE.Enabled = True
                BT_STOP.Enabled = False

                busca_y_cambia_estado_a_respaldando(ID_ACTUAL) ''cambia el estado respaldando
            End If
        Else
            inicia_respaldo()
        End If
       




    End Sub


    Private Sub BT_STOP_Click(sender As Object, e As EventArgs) Handles BT_STOP.Click
        If Me.SUBPRespaldar.ThreadState = Threading.ThreadState.Suspended Then
            Me.SUBPRespaldar.Resume()
            Me.SUBPRespaldar.Abort()
        End If

        If Me.SUBPRespaldar.ThreadState = Threading.ThreadState.Running Then
            Me.SUBPRespaldar.Abort()
        End If

        LB_log.Items.Add("Se ha detenido el proceso de copia de la tarea  ")
        BT_PLAY.Enabled = True
        BT_STOP.Enabled = False


        busca_y_cambia_estado_a_activo(ID_ACTUAL)
        RESPALDO = "DETENIDO"

    End Sub
    Private Function busca_y_cambia_estado_a_activo(ID As Integer)

        Try

            For Each row As DataGridViewRow In DBG_TAREAS.Rows


                Dim campo = row.Cells(1).Value
                If (Not (String.IsNullOrEmpty(campo)) And campo = ID) Then
                    row.Cells(0).Value = "Activa"

                End If

            Next
        Catch ex As Exception

        End Try

    End Function


    Private Function busca_y_cambia_estado_a_respaldando(ID As Integer)

        Try

            For Each row As DataGridViewRow In DBG_TAREAS.Rows


                Dim campo = row.Cells(1).Value
                If (Not (String.IsNullOrEmpty(campo)) And campo = ID) Then
                    row.Cells(0).Value = "Respaldando"

                End If

            Next
        Catch ex As Exception

        End Try

    End Function

    Private Function busca_y_cambia_estado_a_pausado(ID As Integer)

        Try

            For Each row As DataGridViewRow In DBG_TAREAS.Rows


                Dim campo = row.Cells(1).Value
                If (Not (String.IsNullOrEmpty(campo)) And campo = ID) Then
                    row.Cells(0).Value = "Pausado"

                End If

            Next
        Catch ex As Exception

        End Try

    End Function
    Private Function busca_usuario(ID As Integer)
        Dim usuario
        For Each row As DataGridViewRow In DBG_TAREAS.Rows


            Dim campo = row.Cells(1).Value
            If Not (String.IsNullOrEmpty(campo)) Then
                usuario = row.Cells(3).Value.ToString
                Return usuario

            End If

        Next


    End Function

    Private Sub cambia_a_0_ultimo_respaldo(ID As Integer)
        Try
            For Each row As DataGridViewRow In DBG_TAREAS.Rows
                ''If Not (String.IsNullOrEmpty(row.Cells(1).Value.ToString))  Then
                Dim campo = row.Cells(1).Value
                If Not (String.IsNullOrEmpty(campo)) And campo = ID Then
                    row.Cells(COL_ULT_RESPALDO).Value = 0
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Function busca_equipo(ID As Integer)
        Dim equipo
        For Each row As DataGridViewRow In DBG_TAREAS.Rows

            Dim campo = row.Cells(1).Value
            If Not (String.IsNullOrEmpty(campo)) Then
                equipo = row.Cells(2).Value.ToString
                Return equipo

            End If

        Next


    End Function


 

    Private Sub EditarTareaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarTareaToolStripMenuItem1.Click
        If Not (String.IsNullOrEmpty(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value)) Then
            ID_SELECCIONADO = DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
            FRM_Tarea.ShowDialog()
        End If


    End Sub

    Private Sub Timer_Ping_Tick(sender As Object, e As EventArgs) Handles Timer_Ping.Tick
        Static Sec As Integer, Min As Integer

        Sec = Sec + 1



        If Sec = 60 Then   ''' cada 60 segundo busca equipos disponibles
            ''Min = Min + 1
            Sec = 0

            ' If Min = 1 Then

            ' Pongo el codigo a ejecutar aquí

            Me.SUBPping = New Threading.Thread(AddressOf Me.Funcion_ping)
            If Me.SUBPping.ThreadState <> Threading.ThreadState.Running Then
                Me.SUBPping.Start()
            End If



            Min = 0

            'End If
        End If
    End Sub

    Private Sub Actualiza_Tareas()
        Try
            For Each row As DataGridViewRow In DBG_TAREAS.Rows
                Dim i As Integer
                Dim dts As New vworkgen
                Dim funcID As New fworkgen
                dt_workgen = funcID.mostrar_workgen()


                For i = 0 To dt_workgen.Rows.Count - 1 Step 1

                    If row.Cells(COL_ID).Value = dt_workgen.Rows(i).Item(1) Then
                        row.Cells(COL_ESTADO).Value = dt_workgen.Rows(i).Item(0)

                        row.Cells(COL_EQUIPO).Value = dt_workgen.Rows(i).Item(2)
                        row.Cells(COL_USER).Value = dt_workgen.Rows(i).Item(3)
                        row.Cells(COL_USUARIO).Value = dt_workgen.Rows(i).Item(4)
                        row.Cells(COL_GRUPO).Value = dt_workgen.Rows(i).Item(5)
                        row.Cells(COL_IP_EQUIPO).Value = dt_workgen.Rows(i).Item(6)
                        row.Cells(COL_TIPO_EQUIPO).Value = dt_workgen.Rows(i).Item(7)
                        row.Cells(COL_ULT_RESPALDO).Value = dt_workgen.Rows(i).Item(10)


                        'End If
                    End If

                    i = i + 1
                Next



            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Menu_Estado_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Menu_Estado.Opening
        Try

    
        '''si la fila no esta vacia permite visualizar el menu
        If Not (String.IsNullOrEmpty(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString)) Then

            EjecutarTareaAhoraToolStripMenuItem.Enabled = True

            NuevaTareaToolStripMenuItem.Enabled = True
            EditarTareaToolStripMenuItem1.Enabled = True
            ClonarTareaToolStripMenuItem.Enabled = True
            BorrarTareaToolStripMenuItem.Enabled = True


            '' Bloquea el boton cuando la tarea ya esta en ejecucion

            If RESPALDO = "INICIADO" Then
                If DBG_TAREAS(COL_ESTADO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString() = "Respaldando" Then
                    EjecutarTareaAhoraToolStripMenuItem.Enabled = False

                Else
                    EjecutarTareaAhoraToolStripMenuItem.Enabled = True
                End If

            End If
        Else
            EjecutarTareaAhoraToolStripMenuItem.Enabled = False

            NuevaTareaToolStripMenuItem.Enabled = False
            EditarTareaToolStripMenuItem1.Enabled = False
            ClonarTareaToolStripMenuItem.Enabled = False
            BorrarTareaToolStripMenuItem.Enabled = False

        End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Timer_Actualiza_Tareas_Tick(sender As Object, e As EventArgs) Handles Timer_Actualiza_Tareas.Tick
        Static Sec As Integer, Min As Integer

        Sec = Sec + 1



        If Sec = 60 Then   ''' cada 60 segundo busca equipos disponibles
            ''Min = Min + 1
            Sec = 0

            ' If Min = 1 Then

            ' Pongo el codigo a ejecutar aquí

            Me.SUBPActualiza_Tarea = New Threading.Thread(AddressOf Me.Actualiza_Tareas)
            If Me.SUBPActualiza_Tarea.ThreadState <> Threading.ThreadState.Running Then
                Me.SUBPActualiza_Tarea.Start()
            End If



            Min = 0

            'End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Timer_Actualiza_Tareas.Enabled = True

    End Sub

    Private Sub BorrarTareaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarTareaToolStripMenuItem.Click

        If DBG_TAREAS(COL_ESTADO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString() = "Respaldando" Then
            msg_box("No se puede Eliminar una Tarea en uso ", estilo_msgbox_informacion, titulo_aplicacion)

        Else

            If MessageBox.Show("Estas seguro que desea Eliminar la Tarea N°:" & DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString() & "-" & DBG_TAREAS(COL_USUARIO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString() & " una vez eliminada no se podrá recuperar..", "◄ AVISO |  ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                Dim ID = DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value

                Dim del As New fworkgen
                Dim val, val2 As Boolean

                ''elimina tarea de la DB
                val = del.elimina_workdet(ID)
                If val Then

                    If val = del.elimina_workgen(ID) Then
                        msg_box("Se ha eliminado la Tarea N°:" & DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString() & "-" & DBG_TAREAS(COL_USUARIO, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString(), estilo_msgbox_informacion, titulo_aplicacion)

                        elimina_tarea_de_grilla(ID)

                    End If


                End If
            End If

        End If

    End Sub

    Private Function elimina_tarea_de_grilla(ID As Integer)
        Try
            Dim tarea
            For Each row As DataGridViewRow In DBG_TAREAS.Rows
                If Not (String.IsNullOrEmpty(row.ToString)) Then
                    If row.Cells(1).Value.ToString = ID Then
                        DBG_TAREAS.Rows.Remove(row)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Function

    Private Sub DBG_TAREAS_Click(sender As Object, e As EventArgs) Handles DBG_TAREAS.Click

        If Not (String.IsNullOrEmpty(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString)) Then
            abre_detalle_de_item_seleccionado(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString())
        Else
            abre_detalle_de_item_seleccionado(0)
        End If

    End Sub


    Private Sub BT_MINIMIZAR_Click(sender As Object, e As EventArgs) Handles BT_MINIMIZAR.Click
        Me.Visible = False         'oculta el Form de la aplicación
        NotifyIcon1.Visible = True 'vuelve visible el icono en la Tray Bar
        NotifyIcon1.ShowBalloonTip("3000", titulo_aplicacion, "La aplicación seguirá abierta en segundo plano en la barra de tareas", ToolTipIcon.Info)
        ToolStripMenu_Abrir.Text = "Abrir"
    End Sub

    Private Sub BT_CERRAR_Click(sender As Object, e As EventArgs) Handles BT_CERRAR.Click
        If MessageBox.Show("Estas seguro que desea salir, se detendra todo proceso de respaldo ", "◄ AVISO |  ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Me.Close()

        End If

    End Sub

    Private Sub NuevaTareaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaTareaToolStripMenuItem.Click
        ID_SELECCIONADO = 0
        FRM_Tarea.ShowDialog()
    End Sub

    
    Private Sub DBG_TAREAS_KeyUp(sender As Object, e As KeyEventArgs) Handles DBG_TAREAS.KeyUp
        If Not (String.IsNullOrEmpty(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString)) Then
            abre_detalle_de_item_seleccionado(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString())
        Else
            abre_detalle_de_item_seleccionado(0)
        End If
    End Sub


    Private Sub DBG_TAREAS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DBG_TAREAS.CellDoubleClick
        If Not (String.IsNullOrEmpty(DBG_TAREAS(1, DBG_TAREAS.CurrentRow.Index).Value.ToString)) Then
            ID_SELECCIONADO = DBG_TAREAS(COL_ID, DBG_TAREAS.CurrentCell.RowIndex).Value.ToString()
            FRM_Tarea.ShowDialog()
        End If
    End Sub

    Private Sub TB_Config_Click(sender As Object, e As EventArgs) Handles TB_Config.Click

    End Sub

    Private Sub BT_ACEPTA_Click(sender As Object, e As EventArgs) Handles BT_ACEPTA.Click

        If valida_config() Then
            Dim pas
            Dim func As New fconfig
            func.actualiza_config(1, TXT_NOMBRE_DOMINIO.Text)
            func.actualiza_config(2, TXT_USUARIO_DOMINIO.Text)

            Dim des As New EncriptarDesencriptar
            pas = des.encriptar128BitRijndael(TXT_CLAVE_DOMINIO.Text, TXT_NOMBRE_DOMINIO.Text + "\" + TXT_USUARIO_DOMINIO.Text)

            func.actualiza_config(3, pas)

            Dim funcINI As New fconfig
            If CB_auto_ini_windows.Checked = True Then
                funcINI.actualiza_config(4, "SI")
            Else
                funcINI.actualiza_config(4, "NO")
            End If
            


            msg_box("Configuración Guardada Correctamente ", estilo_msgbox_informacion, titulo_aplicacion)
        End If

    End Sub

    Private Function valida_config()
        Dim swok As Integer = 0

        swok = 1

        If (swok = 1) And (Trim(TXT_NOMBRE_DOMINIO.Text) = "") And (Len(TXT_NOMBRE_DOMINIO.Text) < 5) Then

            msg_box("Debe ingresar un nombre de dominio", estilo_msgbox_informacion, titulo_aplicacion)
            TXT_NOMBRE_DOMINIO.Focus()
            swok = 0
        End If


          If (swok = 1) And (Trim(TXT_USUARIO_DOMINIO.Text) = "") And (Len(TXT_USUARIO_DOMINIO.Text) < 5) Then
            msg_box("Debe ingresar el nombre de usuario de cuenta de respaldo del dominio", estilo_msgbox_informacion, titulo_aplicacion)
            TXT_USUARIO_DOMINIO.Focus()
            swok = 0
        End If
      

        If (swok = 1) And (Trim(TXT_CLAVE_DOMINIO.Text) = "") And (Len(TXT_CLAVE_DOMINIO.Text) < 5) Then
            msg_box("Debe ingresar la clave de la cuenta de respaldo del dominio", estilo_msgbox_informacion, titulo_aplicacion)
            TXT_CLAVE_DOMINIO.Focus()
            swok = 0
        End If
        

        If swok = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub TBcontrol1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TBcontrol1.SelectedIndexChanged
        Dim conf As New fconfig
        TXT_NOMBRE_DOMINIO.Text = conf.ver_config(1)
        TXT_USUARIO_DOMINIO.Text = conf.ver_config(2)
        Dim pas2
        Dim des As New EncriptarDesencriptar
        pas2 = des.desencriptar128BitRijndael(conf.ver_config(3), TXT_NOMBRE_DOMINIO.Text + "\" + TXT_USUARIO_DOMINIO.Text)

        TXT_CLAVE_DOMINIO.Text = pas2

        Dim valor As String = conf.ver_config(4)

        If conf.ver_config(4) = "SI" Then
            CB_auto_ini_windows.Checked = True

        Else
            CB_auto_ini_windows.Checked = False
        End If


    End Sub



    Private Sub BT_PAUSE_Click(sender As Object, e As EventArgs) Handles BT_PAUSE.Click
        If RESPALDO = "INICIADO" Then


            If Me.SUBPRespaldar.ThreadState = Threading.ThreadState.Running Then
                Me.SUBPRespaldar.Suspend()
                RESPALDO = "PAUSADO"
                LB_log.Items.Add("Se ha pausado el proceso de copia de la tarea  ")
                LB_log.SelectedIndex = LB_log.Items.Count - 1
                BT_PLAY.Enabled = True
                BT_PAUSE.Enabled = False
                BT_STOP.Enabled = True

                busca_y_cambia_estado_a_pausado(ID_ACTUAL) ''cambia el estado a activo


                ''  Label4.Text = SUBPRespaldar.IsAlive
            End If




        End If
    End Sub





    Private Sub DetenerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenu_Detener.Click
        BT_STOP.PerformClick()
    End Sub

    Private Sub ToolStripMenu_Salir_Click(sender As Object, e As EventArgs) Handles ToolStripMenu_Salir.Click
        Dim response
        response = MsgBox("¿Esta Seguro que desea salir de la aplicación?", vbYesNo, titulo_aplicacion)

        If response = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripMenu_Pausar_Click(sender As Object, e As EventArgs) Handles ToolStripMenu_Pausar.Click
        BT_PAUSE.PerformClick()
    End Sub

    Private Sub ToolStripMenu_Iniciar_Click(sender As Object, e As EventArgs) Handles ToolStripMenu_Iniciar.Click
        BT_PLAY.PerformClick()
    End Sub

    Private Sub ToolStripMenu_Abrir_Click(sender As Object, e As EventArgs) Handles ToolStripMenu_Abrir.Click
        If ToolStripMenu_Abrir.Text = "Minimizar" Then
            Me.Visible = False         'oculta el Form de la aplicación
            NotifyIcon1.Visible = True 'vuelve visible el icono en la Tray Bar
            ToolStripMenu_Abrir.Text = "Abrir"
        Else
            ToolStripMenu_Abrir.Text = "Minimizar"
            'NotifyIcon1.Visible = False 'oculta el icono en la Tray Bar
            NotifyIcon1.Visible = True 'vuelve visible el icono en la Tray Bar
            Me.Visible = True           'vuelve visible el Form de la aplicación
        End If
    End Sub

    Private Sub Menu_de_Aplicacion_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Menu_de_Aplicacion.Opening

        If RESPALDO = "INICIADO" Then
            ToolStripMenu_Iniciar.Enabled = False
            ToolStripMenu_Pausar.Enabled = True
            ToolStripMenu_Detener.Enabled = True

        End If

        If RESPALDO = "PAUSADO" Then
            ToolStripMenu_Iniciar.Enabled = True
            ToolStripMenu_Pausar.Enabled = False
            ToolStripMenu_Detener.Enabled = True

        End If

        If RESPALDO = "DETENIDO" Then
            ToolStripMenu_Iniciar.Enabled = True
            ToolStripMenu_Pausar.Enabled = True
            ToolStripMenu_Detener.Enabled = False

        End If

    End Sub

    Private Sub CB_auto_ini_windows_CheckedChanged(sender As Object, e As EventArgs) Handles CB_auto_ini_windows.CheckedChanged
        Dim testFile As System.IO.FileInfo
        testFile = My.Computer.FileSystem.GetFileInfo("Backup.exe")
        Dim folderPath As String = testFile.DirectoryName
        Dim NOMBRE As String = testFile.FullName

        If CB_auto_ini_windows.Checked = True Then
            ''rutina para autoiniciar el programa en windows
            Try   ''''''''''cambiado de currenuser a LocalMachine
                Dim REGISTRADOR As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                If REGISTRADOR Is Nothing Then
                    Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run")
                End If
                ''  Dim NOMBRE As String = TextBox1.Text
                NOMBRE = NOMBRE.Remove(0, NOMBRE.LastIndexOf("\") + 1)
                REGISTRADOR.SetValue(NOMBRE, testFile.FullName, RegistryValueKind.String)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Else
            '' rutina que saca el autoinicio del programa en windows
            Try   ''''''''''cambiado de currenuser a LocalMachine
                Dim REGISTRADOR As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                If REGISTRADOR IsNot Nothing Then
                    '' Dim NOMBRE As String = TextBox1.Text
                    NOMBRE = NOMBRE.Remove(0, NOMBRE.LastIndexOf("\") + 1)
                    REGISTRADOR.DeleteValue(NOMBRE, False)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WakeUp("00-0F-5D-FA-25-0C")
    End Sub
End Class

