﻿Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base

Public Class frmEntriStockOpname
    Dim SQL As String = ""
    Public Enum pStatus
        Baru = 0
        Edit = 1
    End Enum
    Public pTipe As pStatus
    Public IsPosted As Boolean = False
    Public NoID As Long = -1
    Dim oda2 As SqlDataAdapter
    Dim IDAdmin As Long = -1
    Dim oDS As New DataSet
    Dim BS As New BindingSource
    'For Back Action
    Public FormNameDaftar As String = ""
    Public TableNameDaftar As String = ""
    Public TextDaftar As String = ""
    Public FormEntriDaftar As String = ""
    Public TableMasterDaftar As String = ""
    Dim IsTempInsertBaru As Boolean = False

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT NoID, Kode, Nama FROM MAlamat WHERE IsActive=1 AND IsPegawai=1"
            ds = ExecuteDataset("master", SQL)
            txtPegawai.Properties.DataSource = ds.Tables("master")
            txtPegawai.Properties.ValueMember = "NoID"
            txtPegawai.Properties.DisplayMember = "Nama"
            If System.IO.File.Exists(folderLayouts & Me.Name & gvPegawai.Name & ".xml") Then
                gvPegawai.RestoreLayoutFromXml(folderLayouts & Me.Name & gvPegawai.Name & ".xml")
            End If

            SQL = "SELECT NoID, Kode, Nama FROM MWilayah WHERE IsActive=1 "
            ds = ExecuteDataset("master", SQL)
            txtWilayah.Properties.DataSource = ds.Tables("master")
            txtWilayah.Properties.ValueMember = "NoID"
            txtWilayah.Properties.DisplayMember = "Nama"
            If System.IO.File.Exists(folderLayouts & Me.Name & gvWilayah.Name & ".xml") Then
                gvWilayah.RestoreLayoutFromXml(folderLayouts & Me.Name & gvWilayah.Name & ".xml")
            End If

        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Dim DefImageList As New ImageList

    Private Sub frmEntriPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsTempInsertBaru Then
            If XtraMessageBox.Show("Yakin ingin keluar?" & vbCrLf & "Ya, akan menghapus transaksi dan detil item.", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                EksekusiSQL("DELETE FROM MStockOpname WHERE NoID=" & NoID)
                EksekusiSQL("DELETE FROM MStockOpnameD WHERE IDHeader=" & NoID)
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Sub HighLightTxt()
        For Each ctrl In LayoutControl1.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.TextEdit Then
                AddHandler TryCast(ctrl, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf txt_GotFocus
            End If
        Next
    End Sub
    Private Sub frmEntriPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dlg As DevExpress.Utils.WaitDialogForm = Nothing
        Try
            Dim curentcursor As Cursor = Windows.Forms.Cursor.Current
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            dlg = New DevExpress.Utils.WaitDialogForm(String.Format("Creating component and analize database.{0}MOHON TUNGGU ...", vbCrLf), Application.ProductName)
            dlg.TopMost = False
            dlg.Show()
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            SetTombol()
            RefreshData()
            SetTombol()
            Me.Width = Ini.BacaIniPath(folderLayouts & Me.Name & ".ini", "Form", "Width", Me.Width)
            Me.Height = Ini.BacaIniPath(folderLayouts & Me.Name & ".ini", "Form", "Height", Me.Height)

            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2

            If System.IO.File.Exists(folderLayouts & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(folderLayouts & Me.Name & LayoutControl1.Name & ".xml")
            End If
            If System.IO.File.Exists(folderLayouts & Me.Name & GV1.Name & ".xml") Then
                GV1.RestoreLayoutFromXml(folderLayouts & Me.Name & GV1.Name & ".xml")
            End If
            FungsiControl.SetForm(Me)
            txtJam.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm"
            HighLightTxt()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
            dlg.Close()
            dlg.Dispose()
        End Try
    End Sub
    Private Sub RefreshData()
        Dim DS As New DataSet
        Try
            RefreshDataKontak()
            If pTipe = pStatus.Baru Then
                IsiDefault()
            Else
                SQL = "SELECT MStockOpname.*, MUserEntri.Nama AS UserEntri, MUserEdit.Nama AS UserEdit, MUserPosting.Nama AS UserPosting, MAlamat.Alamat AS Alamat, MAlamat.Nama AS NamaAlamat, MAlamat.Kode as KodeAlamat "
                SQL &= " FROM MStockOpname LEFT JOIN MAlamat ON MAlamat.NoID=MStockOpname.IDPegawai "
                SQL &= " LEFT JOIN MUser MUserEntri ON MUserEntri.NoID=MStockOpname.IDUserEntry "
                SQL &= " LEFT JOIN MUser MUserEdit ON MUserEdit.NoID=MStockOpname.IDUserEdit "
                SQL &= " LEFT JOIN MUser MUserPosting ON MUserPosting.NoID=MStockOpname.IDUserPosting "
                SQL &= " WHERE MStockOpname.NoID = " & NoID
                DS = ExecuteDataset("Tabel", SQL)
                If DS.Tables("Tabel").Rows.Count >= 1 Then
                    txtPegawai.EditValue = NullTolong(DS.Tables(0).Rows(0).Item("IDPegawai"))
                    txtWilayah.EditValue = NullTolong(DS.Tables(0).Rows(0).Item("IDWilayah"))
                    txtKode.Text = NullTostr(DS.Tables(0).Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtKodeReff.Text = NullTostr(DS.Tables(0).Rows(0).Item("KodeReff"))
                    txtTglDitetapkanSO.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("TglDitetapkanSO"))
                    txtTgl.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("Tanggal"))
                    txtJam.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("Jam"))
                    IsPosted = NullTobool(DS.Tables(0).Rows(0).Item("IsPosted"))
                    txtDientriOleh.Text = NullTostr(DS.Tables(0).Rows(0).Item("UserEntri"))
                    txtDieditOleh.Text = NullTostr(DS.Tables(0).Rows(0).Item("UserEdit"))
                    txtDipostingOleh.Text = NullTostr(DS.Tables(0).Rows(0).Item("UserPosting"))
                    tglEntri.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("TglEntri"))
                    tglEdit.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("TglEdit"))
                    tglPosting.DateTime = NullToDate(DS.Tables(0).Rows(0).Item("TglPosting"))
                    txtCatatan.Text = NullTostr(DS.Tables(0).Rows(0).Item("Keterangan"))
                    If IsPosted Then
                        cmdSave.Enabled = False
                    End If
                Else
                    IsiDefault()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            RefreshDetil()
            DS.Dispose()
        End Try
    End Sub
    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)
        If txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Then
            txt.SelectAll()
        End If
    End Sub
    Public Sub RefreshDetil()
        Dim strsql As String
        Dim curentcursor As Cursor = Windows.Forms.Cursor.Current
        Dim repChekEdit As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            strsql = "SELECT MStockOpnameD.*, MStockOpnameD.Qty AS QtySelisih, MStockOpnameD.QtyPcs AS [QtySelisih (Pcs)], MBarangD.Barcode, MBarangD.Varian AS [Varian/Ukuran], MBarang.Nama, MBarang.Nama + ' ' + IsNull(MBarangD.Varian,'') AS NamaStock, MGudang.Nama AS Gudang, MBarang.Kode AS KodeStock, MSatuan.Nama AS Satuan, MSatuan.Kode AS KodeSatuan " & vbCrLf & _
                     " FROM MStockOpnameD " & vbCrLf & _
                     " LEFT JOIN MBarangD ON MBarangD.NoID=MStockOpnameD.IDBarangD" & vbCrLf & _
                     " LEFT JOIN MBarang ON MBarang.NoID=MStockOpnameD.IDBarang" & vbCrLf & _
                     " LEFT JOIN MGudang ON MGudang.NoID=MStockOpnameD.IDGudang" & vbCrLf & _
                     " LEFT JOIN MSatuan ON MSatuan.NoID=MStockOpnameD.IDSatuan" & vbCrLf & _
                     " WHERE MStockOpnameD.IDHeader = " & NoID
            ExecuteDBGrid(GC1, strsql, "NoID")
            For x As Integer = 0 To GV1.Columns.Count - 1
                Select Case GV1.Columns(x).ColumnType.Name.ToLower
                    Case "int32", "int64", "int"
                        GV1.Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GV1.Columns(x).DisplayFormat.FormatString = "n0"
                    Case "decimal", "single", "money", "double"
                        GV1.Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GV1.Columns(x).DisplayFormat.FormatString = "n2"
                    Case "string"
                        GV1.Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        GV1.Columns(x).DisplayFormat.FormatString = ""
                    Case "date", "datetime"
                        If GV1.Columns(x).FieldName.Trim.ToLower = "jam" Then
                            GV1.Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            GV1.Columns(x).DisplayFormat.FormatString = "HH:mm"
                        Else
                            GV1.Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            GV1.Columns(x).DisplayFormat.FormatString = "dd-MM-yyyy"
                        End If
                    Case "boolean"
                        GV1.Columns(x).ColumnEdit = repChekEdit
                End Select
            Next
            GV1.ShowFindPanel()
            HitungTotal()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ".:: Pesan Kesalahan ::.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Windows.Forms.Cursor.Current = curentcursor
        Application.DoEvents()
    End Sub
    Private Sub HitungTotal()
        Dim temp As Double = 0.0
        Try
            For i = 0 To GV1.RowCount
                temp = temp + NullToDbl(GV1.GetRowCellValue(i, "Jumlah"))
            Next
            txtTotal.EditValue = temp
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub IsiDefault()
        SetTombol()
        txtWilayah.EditValue = DefIDWilayah
        RubahWilayah()
        txtTgl.DateTime = TanggalSystem
        txtJam.DateTime = TanggalSystem
        txtTglDitetapkanSO.DateTime = TglDitetapkanSO
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        cmdSave.PerformClick()
    End Sub

    Private Sub cmdTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTutup.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub SetTombol()
        DefImageList = frmMain.ImageList1

        cmdBAru.ImageList = DefImageList
        cmdBAru.ImageIndex = 1

        cmdEdit.ImageList = DefImageList
        cmdEdit.ImageIndex = 2

        cmdDelete.ImageList = DefImageList
        cmdDelete.ImageIndex = 4

        cmdRefresh.ImageList = DefImageList
        cmdRefresh.ImageIndex = 5

        cmdSave.ImageList = DefImageList
        cmdSave.ImageIndex = 6

        cmdTutup.ImageList = DefImageList
        cmdTutup.ImageIndex = 3

        If pTipe = pStatus.Baru Or IsPosted Then
            cmdBAru.Enabled = False
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        Else
            cmdBAru.Enabled = True
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim dlg As WaitDialogForm
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dlg = New WaitDialogForm(String.Format("Sedang menyimpan data.{0}MOHON TUNGGU ...", vbCrLf), Application.ProductName)
        dlg.TopMost = False
        dlg.Show()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim PesanSalah As String = ""
        If Not IsPosted Then
            If IsValidasi() Then
                HitungTotal()
                If Simpan(PesanSalah) = True Then
                    If pTipe = pStatus.Baru Then
                        KodeLama = txtKode.Text
                        pTipe = pStatus.Edit
                        SetTombol()
                        txtBarang.Focus()
                        IsTempInsertBaru = True
                        'txtKodeSupplier.Properties.ReadOnly = True
                    Else
                        cmdSave.Enabled = False
                        clsPostingMutasiWilayah.PostingStockOpname(NoID)
                        cmdSave.Enabled = True
                        'KODE DIBAWAH UNTUK MEMBUKA FORM HANYA 1
                        Dim frmEntri As frmDaftarMutasiWilayah = Nothing
                        Dim F As Object
                        For Each F In MdiParent.MdiChildren
                            If TypeOf F Is frmDaftarMutasiWilayah Then
                                frmEntri = F
                                If frmEntri.FormName = FormNameDaftar Then
                                    Exit For
                                Else
                                    frmEntri = Nothing
                                End If
                            End If
                        Next
                        If frmEntri Is Nothing Then
                            frmEntri = New frmDaftarMutasiWilayah
                            frmEntri.WindowState = FormWindowState.Maximized
                            frmEntri.MdiParent = Me
                            frmEntri.FormName = FormNameDaftar
                            frmEntri.TableName = TableNameDaftar
                            frmEntri.Text = TextDaftar
                            frmEntri.FormEntriName = FormEntriDaftar
                            frmEntri.TableMaster = TableMasterDaftar
                        End If
                        frmEntri.DirectNoID = NoID
                        frmEntri.ShowNoID = True
                        frmEntri.Show()
                        frmEntri.Focus()

                        IsTempInsertBaru = False
                        'DialogResult = Windows.Forms.DialogResult.OK
                        Close()
                        Dispose()
                    End If
                Else
                    XtraMessageBox.Show("Info Kesalahan : " & vbCrLf & PesanSalah, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        dlg.Close()
        dlg.Dispose()
    End Sub
    Private Function IsValidasi() As Boolean
        If txtKode.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtKode.Focus()
            Return False
            Exit Function
        End If
        If txtPegawai.Text = "" Then
            XtraMessageBox.Show("Nama Pegawai yang meminta masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPegawai.Focus()
            Return False
            Exit Function
        End If
        If txtWilayah.Text = "" Then
            XtraMessageBox.Show("Wilayah masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtWilayah.Focus()
            Return False
            Exit Function
        End If
        If txtTgl.Text = "" Then
            XtraMessageBox.Show("Tanggal masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTgl.Focus()
            Return False
            Exit Function
        End If
        If txtJam.Text = "" Then
            XtraMessageBox.Show("Jam masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTgl.Focus()
            Return False
            Exit Function
        End If
        If CekKodeValid(txtKode.Text, KodeLama, "MStockOpname", "Kode", IIf(pTipe = pStatus.Edit, True, False)) Then
            XtraMessageBox.Show("Kode sudah dipakai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If pTipe = pStatus.Baru Then
                If XtraMessageBox.Show("Lakukan pemberian kode baru?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    txtKode.Text = clsKode.MintaKodeBaru("STO", "MStockOpname", txtTgl.DateTime, NullTolong(txtWilayah.EditValue), 5)
                End If
            End If
            txtKode.Focus()
            Return False
            Exit Function
        End If
        If pTipe = pStatus.Edit AndAlso GV1.RowCount <= 0 Then
            XtraMessageBox.Show("Item detil masih kosong." & vbCrLf & "Isi item detil atau tutup bila ingin membatailkan.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        Return True
    End Function
    Dim KodeLama As String = ""
    Public Function Simpan(ByRef PesanSalah As String) As Boolean
        Dim Sukses As Boolean = False
        Try
            If pTipe = pStatus.Baru Then
                NoID = GetNewID("MStockOpname", "NoID")
                SQL = "INSERT INTO [MStockOpname] ([NoID],[Nomor],[Kode],[KodeReff],[IDWilayah],[Tanggal],[Jam],[IDPegawai],[IDUserEntry],[TglEntri],[IDUserEdit],[IDUserPosting],[IDAdmin],[TglPosting],[IsPosted],[Total],[Keterangan],[TglDitetapkanSO]) VALUES (" & vbCrLf & _
                      NoID & ", " & _
                      NullToLong(GetNewID("MStockOpname", "Nomor")) & ", " & _
                      "'" & FixApostropi(txtKode.Text) & "', " & _
                      "'" & FixApostropi(txtKodeReff.Text) & "', " & _
                      NullToLong(txtWilayah.EditValue) & "," & _
                      "'" & txtTgl.DateTime.ToString("yyyy-MM-dd ") & txtJam.DateTime.ToString("HH:mm") & "', " & _
                      "'" & txtJam.DateTime.ToString("HH:mm") & "', " & _
                      NullToLong(txtPegawai.EditValue) & "," & _
                      IDUserAktif & ", getdate(), " & _
                      "NULL, " & _
                      "NULL, " & _
                      IIf(txtWilayah.Properties.ReadOnly = False Or txtKode.Properties.ReadOnly = False Or txtTgl.Properties.ReadOnly = False Or txtJam.Properties.ReadOnly = False, IDUserAktif, "NULL ") & ", " & _
                      "NULL, " & _
                      "0," & FixKoma(txtTotal.EditValue) & "," & _
                      "'" & FixApostropi(txtCatatan.Text) & "','" & txtTglDitetapkanSO.DateTime.ToString("yyyy-MM-dd") & "')"
            Else
                SQL = "UPDATE MStockOpname SET " & vbCrLf & _
                      "Kode='" & FixApostropi(txtKode.Text) & "', " & _
                      "KodeReff='" & FixApostropi(txtKodeReff.Text) & "', " & _
                      "IDWilayah=" & NullToLong(txtWilayah.EditValue) & "," & _
                      "Tanggal='" & txtTgl.DateTime.ToString("yyyy-MM-dd ") & txtJam.DateTime.ToString("HH:mm") & "', " & _
                      "Jam='" & txtJam.DateTime.ToString("HH:mm") & "', " & _
                      "TglDitetapkanSO='" & txtTglDitetapkanSO.DateTime.ToString("yyyy-MM-dd") & "', " & _
                      "IDPegawai=" & NullToLong(txtPegawai.EditValue) & "," & _
                      "IDUserEdit=" & IDUserAktif & "," & _
                      "Total=" & FixKoma(txtTotal.EditValue) & "," & _
                      "Keterangan='" & FixApostropi(txtCatatan.Text) & "'," & _
                      "TglEdit=getdate()"
                If txtWilayah.Properties.ReadOnly = False Or txtKode.Properties.ReadOnly = False Or txtTgl.Properties.ReadOnly = False Or txtJam.Properties.ReadOnly = False Then
                    SQL &= ", IDAdmin=" & IDUserAktif
                End If
                SQL &= " WHERE NoID=" & NoID
            End If
            EksekusiSQL(SQL)
            Sukses = True
        Catch ex As Exception
            PesanSalah = ex.Message
            Sukses = False
        Finally

        End Try
        Return Sukses
    End Function

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnSaveLayout.ItemClick
        Dim xOtorisasi As New frmOtorisasiAdmin
        Try
            If XtraMessageBox.Show("Simpan Layout?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes AndAlso xOtorisasi.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Ini.TulisIniPath(folderLayouts & Me.Name & ".ini", "Form", "Width", Me.Width)
                Ini.TulisIniPath(folderLayouts & Me.Name & ".ini", "Form", "Height", Me.Height)
                Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
                Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2

                LayoutControl1.SaveLayoutToXml(folderLayouts & Me.Name & LayoutControl1.Name & ".xml")
                GV1.SaveLayoutToXml(folderLayouts & Me.Name & GV1.Name & ".xml")
                gvPegawai.SaveLayoutToXml(folderLayouts & Me.Name & gvPegawai.Name & ".xml")
                gvWilayah.SaveLayoutToXml(folderLayouts & Me.Name & gvWilayah.Name & ".xml")
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            xOtorisasi.Dispose()
        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshDetil()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim view As ColumnView = GC1.FocusedView
        Try
            Dim row As System.Data.DataRow = view.GetDataRow(GV1.FocusedRowHandle)
            Dim dc As Integer = GV1.FocusedRowHandle
            Dim IDDetil As Long = NullTolong(row("NoID"))
            If XtraMessageBox.Show("Item " & GV1.GetRowCellValue(GV1.FocusedRowHandle, "NamaStock") & " ini mau dihapus?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                EksekusiSQL("Delete From MStockOpnameD where NoID=" & IDDetil.ToString)
                RefreshDetil()
            End If
            txtBarang.Focus()
        Catch ex As Exception
            XtraMessageBox.Show("Untuk menghapus pilih item barang yang akan dihapus terlebih dahulu lalu tekan tombol hapus", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Tgl_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTgl.EditValueChanged
        Dim TglAdd As Long = 0
        Try
            If pTipe = pStatus.Baru Then
                txtKode.Text = clsKode.MintaKodeBaru("STO", "MStockOpname", txtTgl.DateTime, NullTolong(txtWilayah.EditValue), 5)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBarang_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBarang.ButtonClick
        If pTipe = pStatus.Baru Then Exit Sub
        Select Case e.Button.Index
            Case 0
                InsertIntoDetil()
                txtBarang.Text = ""
                txtBarang.Focus()
            Case 1
                txtBarang.Text = ""
        End Select
    End Sub
    Private Function CariBarang(ByRef IDBarangD As Long, ByRef IDBarang As Long, ByRef NamaBarang As String) As Boolean
        Dim x As Boolean = False
        Dim SQL As String = ""
        Dim oDS As New DataSet
        Try
            SQL = "SELECT MBarangD.NoID, MBarangD.IDBarang, MBarang.Kode,MBarang.Nama FROM MBarang INNER JOIN MBarangD ON MBarangD.IDBarang=MBarang.NoID WHERE MBarang.IsActive=1 AND MBarangD.IsActive=1 AND (ISNULL(MBarang.KODE,'')<>'') AND (UPPER(MBarangD.Barcode) = '" & NamaBarang.Replace("'", "''").ToUpper & "' OR UPPER(MBarang.Kode) = '" & NamaBarang.Replace("'", "''").ToUpper & "' OR UPPER(MBarang.NAMA) = '" & NamaBarang.Replace("'", "''").ToUpper & "') ORDER BY MBarang.Kode"
            oDS = ExecuteDataset("Tbl", SQL)
            If oDS.Tables("Tbl").Rows.Count >= 1 Then
                NamaBarang = NullToStr(oDS.Tables(0).Rows(0).Item("Nama"))
                IDBarangD = NullToLong(oDS.Tables(0).Rows(0).Item("NoID"))
                IDBarang = NullToLong(oDS.Tables(0).Rows(0).Item("IDBarang"))
                x = True
            Else
                x = False
            End If
        Catch ex As Exception
            x = False
        End Try
        Return x
    End Function
    Private Sub InsertIntoDetil()
        Dim SQL As String = ""
        Dim NamaBarang As String = txtBarang.Text
        Dim IDBarang As Long = -1, IDBarangD As Long = -1
        Dim IDDetil As Long = -1
        Dim frmEntri As New frmEntriStockOpnameD
        Dim Konversi As Double = 0.0
        Dim HargaPokok As Double = 0.0
        Try
            If txtWilayah.Text <> "" Then
                If CariBarang(IDBarangD, IDBarang, NamaBarang) Then
                    If XtraMessageBox.Show("Ingin menambah barang " & NamaBarang, "Fast Entri Says", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        'IDDetil = GetNewID("MStockOpnameD", "NoID")
                        'Konversi = NullToDbl(EksekusiSQlSkalarNew("SELECT Konversi FROM MBarangD WHERE IDBarang=" & IDBarang & " AND IDSatuan=" & DefIDSatuan))
                        'HargaPokok = NullToDbl(EksekusiSQlSkalarNew("SELECT HPP FROM MBarang WHERE NoID=" & IDBarang))
                        'If Konversi <> 0 Then
                        '    SQL = "INSERT INTO MStockOpnameD (NoID,IDHeader,IDBarang,IDSatuan,Konversi,HargaPokok) VALUES " & vbCrLf
                        '    SQL &= "(" & IDDetil & "," & NoID & "," & IDBarang & "," & DefIDSatuan & "," & FixKoma(Konversi) & "," & FixKoma(HargaPokok) & ")"
                        'Else
                        '    SQL = "INSERT INTO MStockOpnameD (NoID,IDHeader,IDBarang,HargaPokok) VALUES " & vbCrLf
                        '    SQL &= "(" & IDDetil & "," & NoID & "," & IDBarang & "," & FixKoma(HargaPokok) & ")"
                        'End If
                        'EksekusiSQL(SQL)
                        frmEntri.IsNew = True
                        frmEntri.NoID = -1
                        frmEntri.IDHeader = NoID
                        frmEntri.IDWilayah = NullToLong(txtWilayah.EditValue)
                        frmEntri.JamSO = Format(txtTgl.DateTime, "yyyy-MM-dd") & " " & txtJam.DateTime.ToString("HH:mm")
                        frmEntri.txtBarcode.EditValue = IDBarangD
                        frmEntri.txtBarang.EditValue = IDBarang
                        frmEntri.txtQtyFisik.Focus()
                        If frmEntri.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                            RefreshDetil()
                            GV1.ClearSelection()
                            GV1.FocusedRowHandle = GV1.LocateByDisplayText(0, GV1.Columns("NoID"), IDDetil.ToString("#,##0"))
                            GV1.SelectRow(GV1.FocusedRowHandle)
                            'Else
                            '    SQL = "DELETE FROM MStockOpnameD WHERE NoID=" & IDDetil
                            '    EksekusiSQL(SQL)
                            '    RefreshDetil()
                            '    GV1.ClearSelection()
                            '    GV1.FocusedRowHandle = GV1.LocateByDisplayText(0, GV1.Columns("NoID"), IDDetil.ToString("#,##0"))
                            '    GV1.SelectRow(GV1.FocusedRowHandle)
                        End If
                    End If
                End If
            Else
                XtraMessageBox.Show("Isi dulu wilayah yang dimintai, lalu click baru.", NamaAplikasi, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Kesalahan : " & ex.Message, "Fast Entri Says", MessageBoxButtons.OK)
            frmEntri.Dispose()
        End Try
    End Sub

    Private Sub cmdBAru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAru.Click
        Dim frmEntri As New frmEntriStockOpnameD
        Try
            Dim IDDetil As Long = -1
            frmEntri.NoID = IDDetil
            frmEntri.IsNew = True
            frmEntri.IDHeader = NoID
            frmEntri.formPemanggil = Me
            If txtWilayah.Text <> "" Then
                frmEntri.IDWilayah = NullTolong(txtWilayah.EditValue)
                frmEntri.NoID = IDDetil
                frmEntri.IsNew = True
                frmEntri.JamSO = Format(txtTgl.DateTime, "yyyy-MM-dd") & " " & txtJam.DateTime.ToString("HH:mm")
                If frmEntri.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    RefreshDetil()
                End If
                txtBarang.Focus()
            Else
                XtraMessageBox.Show("Isi dulu wilayah yang dimintai, lalu click baru.", NamaAplikasi, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Untuk membuat baru tekan tombol baru", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmEntri.Dispose()
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim view As ColumnView = GC1.FocusedView
        Dim frmEntri As New frmEntriStockOpnameD
        Try
            Dim row As System.Data.DataRow = view.GetDataRow(GV1.FocusedRowHandle)
            Dim dc As Integer = GV1.FocusedRowHandle
            Dim IDDetil As Long = NullTolong(row("NoID"))
            If txtWilayah.Text <> "" Then
                frmEntri.IDWilayah = NullTolong(txtWilayah.EditValue)
                frmEntri.IsNew = False
                frmEntri.NoID = IDDetil
                frmEntri.IDHeader = NoID
                frmEntri.FormPemanggil = Me
                frmEntri.JamSO = Format(txtTgl.DateTime, "yyyy-MM-dd") & " " & txtJam.DateTime.ToString("HH:mm")
                If frmEntri.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    RefreshDetil()
                End If
                txtBarang.Focus()
            Else
                XtraMessageBox.Show("Isi dulu wilayah yang dimintai, lalu click Edit.", NamaAplikasi, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Untuk mengedit pilih item satuan yang akan diedit terlebih dahulu lalu tekan tombol edit", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmEntri.Dispose()
        End Try
    End Sub

    Private Sub txtBarang_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarang.EditValueChanged

    End Sub

    Private Sub BarButtonItem2_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If cmdBAru.Enabled Then
            cmdBAru.PerformClick()
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If cmdEdit.Enabled Then
            cmdEdit.PerformClick()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If cmdDelete.Enabled Then
            cmdDelete.PerformClick()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        cmdRefresh.PerformClick()

    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        cmdTutup.PerformClick()
    End Sub

    Private Sub Tgl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTgl.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim x As New frmOtorisasiAdmin
            Try
                If txtTgl.Properties.ReadOnly Then
                    If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        IDAdmin = x.IDUserAdmin
                        txtTgl.Properties.ReadOnly = False
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub txtBarang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarang.KeyDown
        If pTipe = pStatus.Baru Then Exit Sub
        Select Case e.KeyCode
            Case Keys.Enter
                InsertIntoDetil()
                txtBarang.Text = ""
                txtBarang.Focus()
            Case Keys.Escape
                txtBarang.Text = ""
        End Select
    End Sub

    Private Sub txtKode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKode.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim x As New frmOtorisasiAdmin
            Try
                If txtKode.Properties.ReadOnly Then
                    If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        IDAdmin = x.IDUserAdmin
                        txtKode.Properties.ReadOnly = False
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub txtWilayah_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWilayah.EditValueChanged
        RubahWilayah()
    End Sub

    Private Sub RubahWilayah()
        If pTipe = pStatus.Baru Then
            txtKode.Text = clsKode.MintaKodeBaru("STO", "MStockOpname", txtTgl.DateTime, NullTolong(txtWilayah.EditValue), 5)
        End If
    End Sub

    Private Sub txtWilayah_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWilayah.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim x As New frmOtorisasiAdmin
            Try
                If txtWilayah.Properties.ReadOnly Then
                    If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        IDAdmin = x.IDUserAdmin
                        txtWilayah.Properties.ReadOnly = False
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub gvPegawai_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPegawai.DataSourceChanged
        If System.IO.File.Exists(folderLayouts & Me.Name & gvPegawai.Name & ".xml") Then
            gvPegawai.RestoreLayoutFromXml(folderLayouts & Me.Name & gvPegawai.Name & ".xml")
        End If
        With gvPegawai
            For x As Integer = 0 To .Columns.Count - 1
                Select Case .Columns(x).ColumnType.Name.ToLower
                    Case "int32", "int64", "int"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(x).DisplayFormat.FormatString = "n0"
                    Case "decimal", "single", "money", "double"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(x).DisplayFormat.FormatString = "n2"
                    Case "string"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        .Columns(x).DisplayFormat.FormatString = ""
                    Case "date", "datetime"
                        If .Columns(x).FieldName.Trim.ToLower = "jam" Then
                            .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(x).DisplayFormat.FormatString = "HH:mm"
                        Else
                            .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(x).DisplayFormat.FormatString = "dd-MM-yyyy"
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub gvWilayah_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvWilayah.DataSourceChanged
        If System.IO.File.Exists(folderLayouts & Me.Name & gvWilayah.Name & ".xml") Then
            gvWilayah.RestoreLayoutFromXml(folderLayouts & Me.Name & gvWilayah.Name & ".xml")
        End If
        With gvWilayah
            For x As Integer = 0 To .Columns.Count - 1
                Select Case .Columns(x).ColumnType.Name.ToLower
                    Case "int32", "int64", "int"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(x).DisplayFormat.FormatString = "n0"
                    Case "decimal", "single", "money", "double"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(x).DisplayFormat.FormatString = "n2"
                    Case "string"
                        .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        .Columns(x).DisplayFormat.FormatString = ""
                    Case "date", "datetime"
                        If .Columns(x).FieldName.Trim.ToLower = "jam" Then
                            .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(x).DisplayFormat.FormatString = "HH:mm"
                        Else
                            .Columns(x).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(x).DisplayFormat.FormatString = "dd-MM-yyyy"
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub txtJam_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJam.EditValueChanged

    End Sub

    Private Sub txtJam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtJam.KeyDown
        If e.KeyCode = Keys.F7 Then
            Dim x As New frmOtorisasiAdmin
            Try
                If txtJam.Properties.ReadOnly Then
                    If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        IDAdmin = x.IDUserAdmin
                        txtJam.Properties.ReadOnly = False
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show("Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim x As New frmBacaLogStockOpname
        x.JamSo = txtTgl.DateTime
        x.NoID = NoID
        'x.MdiParent = Me.MdiParent
        x.Show()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim frGen As New frmGenerateStockOpnamePerKategori
        frGen.IDStockOpname = NoID
        frGen.ShowDialog(Me)

        frGen.Dispose()
        RefreshDetil()
        'Dim x As New frmLookup
        'Dim IDKategori = -1
        'Dim ds As New DataSet
        'Dim SQL As String = ""
        'Dim Qty As Double, QtyPcs As Double
        'Dim Tanggal As Date = TanggalSystem
        'Dim tgl As String = ""
        'Try
        '    If pTipe = pStatus.Edit AndAlso IsPosted = False Then
        '        If XtraMessageBox.Show("Yakin ingin mengosongkan Stock Gudang?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
        '            x.Strsql = "SELECT MKategori.* FROM MKategori WHERE MKategori.IsActive=1"
        '            x.FormName = sender.name
        '            If x.ShowDialog(Me)= Windows.Forms.DialogResult.OK Then
        '                IDKategori = x.NoID
        '                tgl = InputBox("Isikan Sampai dengan Tanggal. Format DDMMYYYY", NamaAplikasi, Tanggal.ToString("ddMMyyyy"))
        '                Tanggal = CDate(tgl.Substring(4, 4) & "/" & tgl.Substring(2, 2) & "/" & tgl.Substring(0, 2))
        '                SQL = "SELECT MBarangD.NoID, MBarangD.IDBarang, MBarangD.IDSatuan, MBarangD.Konversi, MBarang.HargaBeliPcs AS HargaPokok, " & vbCrLf & _
        '                      " IsNull((SELECT SUM((MKartuStok.QtyMasuk-MKartuStok.QtyKeluar)*MKartuStok.Konversi) FROM MKartuStok WHERE MKartuStok.IDBarangD=MBarangD.NoID AND MKartuStok.IDBarang=MBarang.NoID AND MKartuStok.IDGudang=" & DefIDGudang & "),0) AS QtyKomputer" & vbCrLf & _
        '                      " FROM " & vbCrLf & _
        '                      " MBarangD INNER JOIN MBarang ON MBarang.NoID=MBarangD.IDBarang" & vbCrLf & _
        '                      " WHERE IsNull((SELECT SUM((MKartuStok.QtyMasuk-MKartuStok.QtyKeluar)*MKartuStok.Konversi) FROM MKartuStok WHERE MKartuStok.IDBarangD=MBarangD.NoID AND MKartuStok.IDBarang=MBarang.NoID AND MKartuStok.IDGudang=" & DefIDGudang & "),0) <>0" & vbCrLf & _
        '                      " AND MBarangD.NoID NOT IN (SELECT MStockOpnameD.IDBarangD FROM MStockOpnameD INNER JOIN MStockOpname ON MStockOpname.NoID=MStockOpnameD.IDHeader WHERE MStockOpname.Tanggal<'" & Tanggal.AddDays(1).ToString("yyyy/MM/dd") & "' AND MStockOpnameD.IDGudang=" & DefIDGudang & ")" & vbCrLf & _
        '                      " AND MBarang.IDKategori=" & IDKategori
        '                ds = ExecuteDataset("MBarangD", SQL)
        '                For i As Integer = 0 To ds.Tables("MBarangD").Rows.Count - 1
        '                    With ds.Tables("MBarangD").Rows(i)
        '                        Qty = 0 - (.Item("QtyKomputer") / IIf(.Item("Konversi") = 0, 1, .Item("Konversi")))
        '                        QtyPcs = Qty * NullToDbl(.Item("Konversi"))
        '                        SQL = "INSERT INTO [MStockOpnameD] ([QtyKomputer],[QtyFisik],[NoID],[IDHeader],[IDBarang],[IDGudang],[IDSatuan],[Konversi],[Qty],[QtyPCS],[Keterangan],[HargaPokok],[Jumlah],[IDBarangD]) VALUES (" & vbCrLf & _
        '                              FixKoma(.Item("QtyKomputer") / IIf(.Item("Konversi") = 0, 1, .Item("Konversi"))) & "," & vbCrLf & _
        '                              FixKoma(0) & "," & vbCrLf & _
        '                              NullToLong(GetNewID("MStockOpnameD", "NoID")) & "," & vbCrLf & _
        '                              NoID & "," & vbCrLf & _
        '                              NullToLong(.Item("IDBarang")) & "," & vbCrLf & _
        '                              NullToLong(DefIDGudang) & "," & vbCrLf & _
        '                              NullToLong(.Item("IDSatuan")) & "," & vbCrLf & _
        '                              FixKoma(.Item("Konversi")) & "," & vbCrLf & _
        '                              FixKoma(Qty) & "," & vbCrLf & _
        '                              FixKoma(QtyPcs) & "," & vbCrLf & _
        '                              "'SO Kosongkan Kategori.'," & vbCrLf & _
        '                              FixKoma(.Item("HargaPokok")) & "," & vbCrLf & _
        '                              FixKoma(0 * NullToDbl(.Item("HargaPokok"))) & "," & vbCrLf & _
        '                              NullToLong(.Item("NoID")) & "" & vbCrLf & _
        '                              ")"
        '                        EksekusiSQL(SQL)
        '                    End With
        '                    Application.DoEvents()
        '                Next
        '                RefreshDetil()
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Finally
        '    ds.Dispose()
        '    x.Dispose()
        'End Try
    End Sub
End Class