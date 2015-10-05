Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Public Class frDaftarAktivaTetap
    Inherits DevExpress.XtraEditors.XtraForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPosting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colNama As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cJumlah As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cBulanEkonomis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cCatatan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNoID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTanggal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTanggalBuku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIsPosted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TglDari As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TglSampai As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents c2NoID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents c2Kode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents c2Tanggal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents c2Jumlah As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdUnposting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chargaBuku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CTanggalHapus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cHargaJual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTipe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CIsAda As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cKode As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frDaftarAktivaTetap))
        Me.c2NoID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.c2Kode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.c2Tanggal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.c2Jumlah = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.cNoID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cTanggal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cKode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colNama = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cTanggalBuku = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cJumlah = New DevExpress.XtraGrid.Columns.GridColumn
        Me.chargaBuku = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cBulanEkonomis = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cCatatan = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cIsPosted = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.CTanggalHapus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cHargaJual = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cTipe = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CIsAda = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.TglSampai = New DevExpress.XtraEditors.DateEdit
        Me.Label14 = New System.Windows.Forms.Label
        Me.TglDari = New DevExpress.XtraEditors.DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdUnposting = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.cmdPosting = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TglSampai.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TglSampai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TglDari.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TglDari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'c2NoID
        '
        Me.c2NoID.Name = "c2NoID"
        '
        'c2Kode
        '
        Me.c2Kode.Name = "c2Kode"
        '
        'c2Tanggal
        '
        Me.c2Tanggal.Name = "c2Tanggal"
        '
        'c2Jumlah
        '
        Me.c2Jumlah.Name = "c2Jumlah"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(105, 2)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(821, 481)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cNoID, Me.cTanggal, Me.cKode, Me.colNama, Me.cTanggalBuku, Me.cJumlah, Me.chargaBuku, Me.cBulanEkonomis, Me.cCatatan, Me.cIsPosted, Me.CTanggalHapus, Me.cHargaJual, Me.cTipe, Me.CIsAda})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(808, 462, 216, 171)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView1.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'cNoID
        '
        Me.cNoID.Caption = "NoID"
        Me.cNoID.FieldName = "NoID"
        Me.cNoID.Name = "cNoID"
        Me.cNoID.Width = 36
        '
        'cTanggal
        '
        Me.cTanggal.Caption = "Tanggal"
        Me.cTanggal.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.cTanggal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cTanggal.FieldName = "Tanggal"
        Me.cTanggal.Name = "cTanggal"
        Me.cTanggal.Visible = True
        Me.cTanggal.VisibleIndex = 2
        Me.cTanggal.Width = 104
        '
        'cKode
        '
        Me.cKode.Caption = "Kode"
        Me.cKode.FieldName = "Kode"
        Me.cKode.Name = "cKode"
        Me.cKode.Visible = True
        Me.cKode.VisibleIndex = 0
        Me.cKode.Width = 36
        '
        'colNama
        '
        Me.colNama.Caption = "Nama"
        Me.colNama.FieldName = "Nama"
        Me.colNama.Name = "colNama"
        Me.colNama.Visible = True
        Me.colNama.VisibleIndex = 1
        Me.colNama.Width = 82
        '
        'cTanggalBuku
        '
        Me.cTanggalBuku.Caption = "Tanggal dibukukan"
        Me.cTanggalBuku.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.cTanggalBuku.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cTanggalBuku.FieldName = "TanggalDibukukan"
        Me.cTanggalBuku.Name = "cTanggalBuku"
        Me.cTanggalBuku.Visible = True
        Me.cTanggalBuku.VisibleIndex = 3
        Me.cTanggalBuku.Width = 74
        '
        'cJumlah
        '
        Me.cJumlah.AppearanceCell.Options.UseTextOptions = True
        Me.cJumlah.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cJumlah.AppearanceHeader.Options.UseTextOptions = True
        Me.cJumlah.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cJumlah.Caption = "Harga Perolehan"
        Me.cJumlah.DisplayFormat.FormatString = "###,###,###,##0.00"
        Me.cJumlah.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cJumlah.FieldName = "HargaPerolehan"
        Me.cJumlah.Name = "cJumlah"
        Me.cJumlah.Visible = True
        Me.cJumlah.VisibleIndex = 5
        Me.cJumlah.Width = 45
        '
        'chargaBuku
        '
        Me.chargaBuku.Caption = "Harga Buku"
        Me.chargaBuku.DisplayFormat.FormatString = "###,##0.00"
        Me.chargaBuku.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.chargaBuku.FieldName = "NilaiDibukukan"
        Me.chargaBuku.Name = "chargaBuku"
        Me.chargaBuku.Visible = True
        Me.chargaBuku.VisibleIndex = 6
        '
        'cBulanEkonomis
        '
        Me.cBulanEkonomis.AppearanceCell.Options.UseTextOptions = True
        Me.cBulanEkonomis.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cBulanEkonomis.AppearanceHeader.Options.UseTextOptions = True
        Me.cBulanEkonomis.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cBulanEkonomis.Caption = "Bulan Ekonomis"
        Me.cBulanEkonomis.DisplayFormat.FormatString = "###,###,###,##0"
        Me.cBulanEkonomis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cBulanEkonomis.FieldName = "BulanEkonomis"
        Me.cBulanEkonomis.Name = "cBulanEkonomis"
        Me.cBulanEkonomis.Visible = True
        Me.cBulanEkonomis.VisibleIndex = 4
        Me.cBulanEkonomis.Width = 40
        '
        'cCatatan
        '
        Me.cCatatan.Caption = "Catatan"
        Me.cCatatan.FieldName = "Catatan"
        Me.cCatatan.Name = "cCatatan"
        Me.cCatatan.Visible = True
        Me.cCatatan.VisibleIndex = 7
        Me.cCatatan.Width = 51
        '
        'cIsPosted
        '
        Me.cIsPosted.AppearanceCell.Options.UseTextOptions = True
        Me.cIsPosted.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIsPosted.AppearanceHeader.Options.UseTextOptions = True
        Me.cIsPosted.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIsPosted.Caption = "IsPosted"
        Me.cIsPosted.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.cIsPosted.FieldName = "IsPosted"
        Me.cIsPosted.Name = "cIsPosted"
        Me.cIsPosted.Visible = True
        Me.cIsPosted.VisibleIndex = 8
        Me.cIsPosted.Width = 54
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'CTanggalHapus
        '
        Me.CTanggalHapus.Caption = "Tanggal Hapus"
        Me.CTanggalHapus.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CTanggalHapus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CTanggalHapus.FieldName = "TanggalHapus"
        Me.CTanggalHapus.Name = "CTanggalHapus"
        Me.CTanggalHapus.Visible = True
        Me.CTanggalHapus.VisibleIndex = 9
        '
        'cHargaJual
        '
        Me.cHargaJual.Caption = "Harga Jual"
        Me.cHargaJual.DisplayFormat.FormatString = "###,##0.00"
        Me.cHargaJual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cHargaJual.FieldName = "HargaJual"
        Me.cHargaJual.Name = "cHargaJual"
        Me.cHargaJual.Visible = True
        Me.cHargaJual.VisibleIndex = 10
        '
        'cTipe
        '
        Me.cTipe.Caption = "Tipe"
        Me.cTipe.FieldName = "Tipe"
        Me.cTipe.Name = "cTipe"
        Me.cTipe.Visible = True
        Me.cTipe.VisibleIndex = 11
        '
        'CIsAda
        '
        Me.CIsAda.Caption = "Asset Masih Ada"
        Me.CIsAda.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.CIsAda.FieldName = "IsAda"
        Me.CIsAda.Name = "CIsAda"
        Me.CIsAda.Visible = True
        Me.CIsAda.VisibleIndex = 12
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        Me.ImageList1.Images.SetKeyName(22, "")
        Me.ImageList1.Images.SetKeyName(23, "")
        Me.ImageList1.Images.SetKeyName(24, "add.png")
        Me.ImageList1.Images.SetKeyName(25, "delete.png")
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.TglSampai)
        Me.PanelControl1.Controls.Add(Me.Label14)
        Me.PanelControl1.Controls.Add(Me.TglDari)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Glass Oceans"
        Me.PanelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(928, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(379, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "s/d"
        '
        'TglSampai
        '
        Me.TglSampai.EditValue = Nothing
        Me.TglSampai.EnterMoveNextControl = True
        Me.TglSampai.Location = New System.Drawing.Point(411, 12)
        Me.TglSampai.Name = "TglSampai"
        Me.TglSampai.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TglSampai.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglSampai.Properties.Appearance.Options.UseBackColor = True
        Me.TglSampai.Properties.Appearance.Options.UseFont = True
        Me.TglSampai.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TglSampai.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TglSampai.Size = New System.Drawing.Size(141, 22)
        Me.TglSampai.TabIndex = 3
        Me.TglSampai.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(108, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Tanggal Perolehan"
        '
        'TglDari
        '
        Me.TglDari.EditValue = Nothing
        Me.TglDari.EnterMoveNextControl = True
        Me.TglDari.Location = New System.Drawing.Point(232, 12)
        Me.TglDari.Name = "TglDari"
        Me.TglDari.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TglDari.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglDari.Properties.Appearance.Options.UseBackColor = True
        Me.TglDari.Properties.Appearance.Options.UseFont = True
        Me.TglDari.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TglDari.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TglDari.Size = New System.Drawing.Size(141, 22)
        Me.TglDari.TabIndex = 1
        Me.TglDari.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(546, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(376, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "DAFTAR AKTIVA TETAP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.Controls.Add(Me.GridControl1)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 38)
        Me.PanelControl2.LookAndFeel.SkinName = "Glass Oceans"
        Me.PanelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(928, 485)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.LightSalmon
        Me.PanelControl3.Appearance.Options.UseBackColor = True
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.SimpleButton9)
        Me.PanelControl3.Controls.Add(Me.SimpleButton8)
        Me.PanelControl3.Controls.Add(Me.cmdOk)
        Me.PanelControl3.Controls.Add(Me.SimpleButton3)
        Me.PanelControl3.Controls.Add(Me.cmdUnposting)
        Me.PanelControl3.Controls.Add(Me.SimpleButton7)
        Me.PanelControl3.Controls.Add(Me.SimpleButton6)
        Me.PanelControl3.Controls.Add(Me.SimpleButton5)
        Me.PanelControl3.Controls.Add(Me.SimpleButton2)
        Me.PanelControl3.Controls.Add(Me.SimpleButton1)
        Me.PanelControl3.Controls.Add(Me.cmdPosting)
        Me.PanelControl3.Controls.Add(Me.SimpleButton4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(103, 481)
        Me.PanelControl3.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOk.ImageIndex = 1
        Me.cmdOk.ImageList = Me.ImageList1
        Me.cmdOk.Location = New System.Drawing.Point(1, 288)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(99, 34)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.Text = "&Simpan"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton3.Location = New System.Drawing.Point(1, 248)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton3.TabIndex = 8
        Me.SimpleButton3.Text = "&View Susut"
        '
        'cmdUnposting
        '
        Me.cmdUnposting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUnposting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUnposting.Location = New System.Drawing.Point(1, 208)
        Me.cmdUnposting.Name = "cmdUnposting"
        Me.cmdUnposting.Size = New System.Drawing.Size(99, 34)
        Me.cmdUnposting.TabIndex = 7
        Me.cmdUnposting.Text = "&Hapus Susut"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton7.ImageIndex = 2
        Me.SimpleButton7.ImageList = Me.ImageList1
        Me.SimpleButton7.Location = New System.Drawing.Point(1, 436)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton7.TabIndex = 0
        Me.SimpleButton7.Text = "&Close"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton6.ImageIndex = 17
        Me.SimpleButton6.ImageList = Me.ImageList1
        Me.SimpleButton6.Location = New System.Drawing.Point(1, 3)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton6.TabIndex = 0
        Me.SimpleButton6.Text = "&Refresh"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton5.ImageIndex = 6
        Me.SimpleButton5.ImageList = Me.ImageList1
        Me.SimpleButton5.Location = New System.Drawing.Point(1, 128)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton5.TabIndex = 3
        Me.SimpleButton5.Text = "&Hapus"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton2.ImageIndex = 0
        Me.SimpleButton2.ImageList = Me.ImageList1
        Me.SimpleButton2.Location = New System.Drawing.Point(1, 83)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "&Edit"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton1.ImageIndex = 10
        Me.SimpleButton1.ImageList = Me.ImageList1
        Me.SimpleButton1.Location = New System.Drawing.Point(1, 43)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "&Baru"
        '
        'cmdPosting
        '
        Me.cmdPosting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPosting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPosting.Location = New System.Drawing.Point(1, 168)
        Me.cmdPosting.Name = "cmdPosting"
        Me.cmdPosting.Size = New System.Drawing.Size(99, 34)
        Me.cmdPosting.TabIndex = 6
        Me.cmdPosting.Text = "&Generate Susut"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton4.ImageIndex = 21
        Me.SimpleButton4.ImageList = Me.ImageList1
        Me.SimpleButton4.Location = New System.Drawing.Point(0, 128)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton4.TabIndex = 4
        Me.SimpleButton4.Text = "&Cancel"
        Me.SimpleButton4.Visible = False
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton8.ImageIndex = 1
        Me.SimpleButton8.ImageList = Me.ImageList1
        Me.SimpleButton8.Location = New System.Drawing.Point(1, 328)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton8.TabIndex = 10
        Me.SimpleButton8.Text = "&Preview"
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton9.ImageIndex = 1
        Me.SimpleButton9.ImageList = Me.ImageList1
        Me.SimpleButton9.Location = New System.Drawing.Point(1, 368)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(99, 34)
        Me.SimpleButton9.TabIndex = 11
        Me.SimpleButton9.Text = "&Export Excel"
        '
        'frDaftarAktivaTetap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(928, 523)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frDaftarAktivaTetap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daftar Aktiva Tetap/Asset"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TglSampai.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TglSampai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TglDari.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TglDari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public IsLookup As Boolean = False
    Public IsGetOnly As Boolean
    Public NoID As Long
    Public Kode As String
    Public Nama As String
    Public row As System.Data.DataRow
    Dim BolehAmbilData As Boolean
    Sub RefreshData()
        Dim oConn As New SqlConnection
        Dim ocmd As SqlCommand
        Dim oDA As SqlDataAdapter
        Dim oDS As New DataSet
        Dim strsql As String
        Dim curentcursor As Cursor = Windows.Forms.Cursor.Current
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        strsql = "SELECT MAsset.*, MTypeAsset.Nama as Tipe " & _
        " From MAsset left Join MTypeAsset " & _
        " On MAsset.IDTypeAsset=MTypeAsset.NoID "
        If TglDari.Enabled Then
            strsql = strsql & " WHERE MAsset.Tanggal>=convert(datetime,'" & Format(TglDari.DateTime, "MM/dd/yyyy") & "',101) AND MAsset.Tanggal<=convert(datetime,'" & Format(TglSampai.DateTime, "MM/dd/yyyy") & "',101)"
        End If
        Try
            oConn.ConnectionString = StrKonSql
            ocmd = New SqlCommand(strsql, oConn)
            oConn.Open()
            oDA = New SqlDataAdapter(ocmd)
            oDA.Fill(oDS, "MAsset")
        Catch ex As Exception
            XtraMessageBox.Show(Me, ex.Message, ".:: Pesan Kesalahan ::.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oConn.Close()
        End Try
        GridControl1.DataSource = oDS.Tables("MAsset")
        'GridControl1.DataSource = oDS.Tables("DETAIL")
        Windows.Forms.Cursor.Current = curentcursor
    End Sub

    Private Sub frDaftarAktivaTetap_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'GridToPrint = GridControl1
    End Sub

    Private Sub frDaftarAktivaTetap_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        'GridToPrint = Nothing
    End Sub

    Private Sub frDaftarPinjaman_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GridView1.SaveLayoutToXml(Application.StartupPath & "\system\layouts\" & Me.Name & GridView1.Name & ".xml")
        'GridView2.SaveLayoutToXml(Application.StartupPath & "\layout\" & Me.Name & GridView2.Name & ".xml")
    End Sub
    Private Sub frDaftarBBM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsGetOnly Then PanelControl3.Visible = False
        TglDari.DateTime = Date.Today
        TglSampai.DateTime = Date.Today
        RefreshData()
        If Dir(Application.StartupPath & "\system\layouts\" & Me.Name & GridView1.Name & ".xml") <> "" Then
            GridView1.RestoreLayoutFromXml(Application.StartupPath & "\system\layouts\" & Me.Name & GridView1.Name & ".xml")
        End If
        Setme()
    End Sub

    Private Sub Setme()
        'SetButton(cmdPosting, button_.cmdPosting)
        'SetButton(cmdUnposting, button_.cmdUnposting)
    End Sub
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPosting.Click
        Try
            Dim view As ColumnView = GridControl1.FocusedView
            Dim I As Integer
            Dim focusrow As Long
            focusrow = GridView1.FocusedRowHandle

            For I = 0 To view.SelectedRowsCount - 1
                Dim row As System.Data.DataRow = view.GetDataRow(view.GetSelectedRows(I))
                NoID = NullToLong(row("NoID"))
                If NullToBool(row("IsPosted")) = False Then
                    BuatPenyusutan(row)
                    'clsSqlServer.EksekusiSQl("UPDATE MPiutangKaryawan SET IsPosted=1 where NoID=" & NoID)
                End If
            Next
            RefreshData()

            GridView1.FocusedRowHandle = focusrow
            GridView1.SelectRow(focusrow)
        Catch ex As Exception
            XtraMessageBox.Show(Me, ex.Message, ".:: Pesan Kesalahan ::.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub BuatPenyusutan(ByVal Row As System.Data.DataRow)
        Dim Bulan As Integer = NullToLong(Row("BulanEkonomis"))
        Dim TanggalAwal As DateTime = NullToDate(Row("TanggalDibukukan"))
        Dim TanggalHapus As DateTime = NullToDate(Row("TanggalHapus"))
        Dim Tanggal As DateTime
        Dim SusutPerbulan As Double
        Dim NoIDDetil As Long
        Dim IsAda As Boolean = NullToBool(Row("IsAda"))
        If Bulan > 0 Then
            SusutPerbulan = (NullToDbl(Row("NilaiDibukukan")) - NullToDbl(Row("NilaiSisa"))) / Bulan
            Dim i As Integer 'NilaiDibukukan,TanggalDibukukan
            For i = 0 To Bulan - 1
                If IsAda Or DateAdd(DateInterval.Month, i, TanggalAwal) <= TanggalHapus Then

                    NoIDDetil = GetNewID("MAssetD", "NoID")
                    Tanggal = DateAdd(DateInterval.Month, i, TanggalAwal)
                    EksekusiSQL("Insert into MassetD(NoID,IDAsset,Tanggal,NoBulan,HargaSusut)" & _
                    "values(" & NoIDDetil.ToString & "," & NoID.ToString & ",convert(datetime,'" & Format(Tanggal, "MM/dd/yyyy") & "',101)," & (i + 1).ToString & "," & FixKoma(SusutPerbulan) & ")")
                End If
            Next
        End If
        Application.DoEvents()
        EksekusiSQL("Update MAsset set IsPosted=1 where NoID=" & NoID.ToString)

    End Sub
    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim frmEntri As New frEntriAktivaTetap
        frmEntri.pStatus_ = frEntriAktivaTetap.pStatus.Baru
        If frmEntri.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            RefreshData()
        End If
        frmEntri.Dispose()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim view As ColumnView = GridControl1.FocusedView
        Try
            Dim row As System.Data.DataRow = view.GetDataRow(GridView1.FocusedRowHandle)
            Dim NoID As Long = row("NoID")
            Dim focusrow As Long
            focusrow = GridView1.FocusedRowHandle

            Dim frmEntri As New frEntriAktivaTetap
            frmEntri.pStatus_ = frEntriAktivaTetap.pStatus.Edit
            frmEntri.NoID = NoID
            If NullToBool(row("IsPosted")) Then
                frmEntri.cmdSimpan.Enabled = False
            End If
            If frmEntri.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                RefreshData()

                GridView1.FocusedRowHandle = focusrow
                GridView1.SelectRow(focusrow)
            End If
            frmEntri.Dispose()
        Catch ex As Exception
            XtraMessageBox.Show(Me, "Untuk mengedit pilih data yang akan diedit terlebih dahulu lalu tekan tombol edit", ".:: Pesan Kesalahan ::.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub SimpleButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton5.Click
        Dim view As ColumnView = GridControl1.FocusedView
        Dim row As System.Data.DataRow = view.GetDataRow(GridView1.FocusedRowHandle)
        Dim NoId As Long = row("NOID")
        If Not NullToBool(row("IsPosted")) Then
            If XtraMessageBox.Show(Me, "Yakin Mau Hapus data ini?", ".:: Hapus Data Asset ::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DeleteRowByID("MAsset", "NoID", NoId)
                RefreshData()
            End If
        End If
    End Sub

    Private Sub SimpleButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton6.Click
        RefreshData()
    End Sub

    Private Sub GridControl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            AmbilData()
        ElseIf e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        AmbilData()
    End Sub
    Sub AmbilData()
        Dim view As ColumnView = GridControl1.FocusedView
        Dim row As System.Data.DataRow = view.GetDataRow(GridView1.FocusedRowHandle)
        NoID = row("NoID")
        Kode = row("Kode")
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    '

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GridControl1_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        If IsLookup Then
            cmdOk.PerformClick()
        Else
            SimpleButton2.PerformClick()
        End If
    End Sub

    Private Sub GridControl1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton2.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub GridControl1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridControl1.MouseDown
        Dim HI As New DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
        HI = GridView1.CalcHitInfo(e.X, e.Y)
        If HI.InRow Then
            BolehAmbilData = True
        Else
            BolehAmbilData = False
        End If
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        TglDari.Enabled = Not TglDari.Enabled
        TglSampai.Enabled = TglDari.Enabled
    End Sub

    Private Sub cmdUnposting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnposting.Click
        Try
            Dim view As ColumnView = GridControl1.FocusedView
            Dim I As Integer
            Dim focusrow As Long
            focusrow = GridView1.FocusedRowHandle

            For I = 0 To view.SelectedRowsCount - 1
                Dim row As System.Data.DataRow = view.GetDataRow(view.GetSelectedRows(I))
                NoID = NullToLong(row("NoID"))
                If NullToBool(row("IsPosted")) = True Then
                    EksekusiSQL("Delete from MAssetD where  IDAsset=" & NoID.ToString & " and (IsPost =0 or IsPost IS Null)")
                    If EksekusiSQLSkalar("Select Count(NoID) as Hasil from MAssetD where  IDAsset=" & NoID.ToString) <= 0 Then
                        EksekusiSQL("Update MAsset set IsPosted=0 where NoID=" & NoID.ToString)
                    End If
                    'BuatPenyusutan()
                    'clsSqlServer.EksekusiSQl("UPDATE MPiutangKaryawan SET IsPosted=1 where NoID=" & NoID)
                End If
            Next
            RefreshData()
            GridView1.FocusedRowHandle = focusrow
            GridView1.SelectRow(focusrow)
        Catch ex As Exception
            XtraMessageBox.Show(Me, ex.Message, ".:: Pesan Kesalahan ::.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim view As ColumnView = GridControl1.FocusedView
            row = view.GetDataRow(GridView1.FocusedRowHandle)
            NoID = NullToLong(row("NoID"))
            Kode = NullToStr(row("Kode"))
            Nama = NullToStr(row("Nama"))

            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("Ada kesalahan: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SimpleButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Dim x As New frDaftarPenyusutanAktiva
        Try
            Dim view As ColumnView = GridControl1.FocusedView
            row = view.GetDataRow(GridView1.FocusedRowHandle)
            NoID = NullToLong(row("NoID"))
            Kode = NullToStr(row("Kode"))
            Nama = NullToStr(row("Nama"))


            x.txtTipe.Enabled = False
            x.txtAsset.Enabled = True
            x.IDAsset = NoID
            x.TglDari.Enabled = False
            x.TglSampai.Enabled = False
            x.txtAsset.Text = Nama
            x.ShowDialog(Me)
            x.Dispose()

        Catch ex As Exception
            MsgBox("Ada kesalahan: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SimpleButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton8.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton9.Click
        Dim dlgsave As New SaveFileDialog
        dlgsave.Title = "Export Daftar ke Excel"
        dlgsave.Filter = "Excel Files|*.xls"
        If dlgsave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToXls(dlgsave.FileName)
            BukaFile(dlgsave.FileName)
        End If
        dlgsave.Dispose()
    End Sub
End Class

