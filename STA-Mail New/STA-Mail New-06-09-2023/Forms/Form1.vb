Imports System.Messaging
Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btRecive As System.Windows.Forms.Button
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents txtLabel As System.Windows.Forms.TextBox
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQueue As System.Windows.Forms.TextBox
    Friend WithEvents btCreate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btRecive = New System.Windows.Forms.Button
        Me.btDelete = New System.Windows.Forms.Button
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.txtLabel = New System.Windows.Forms.TextBox
        Me.btSend = New System.Windows.Forms.Button
        Me.txtMsg = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtQueue = New System.Windows.Forms.TextBox
        Me.btCreate = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtBody = New System.Windows.Forms.TextBox
        Me.btRefresh = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btRecive
        '
        Me.btRecive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRecive.Location = New System.Drawing.Point(128, 328)
        Me.btRecive.Name = "btRecive"
        Me.btRecive.Size = New System.Drawing.Size(120, 32)
        Me.btRecive.TabIndex = 6
        Me.btRecive.Text = "Delete &Message"
        '
        'btDelete
        '
        Me.btDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDelete.Location = New System.Drawing.Point(272, 328)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(104, 32)
        Me.btDelete.TabIndex = 7
        Me.btDelete.Text = "&Delete Queue"
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(16, 8)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(248, 296)
        Me.TreeView1.TabIndex = 0
        '
        'txtLabel
        '
        Me.txtLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLabel.Location = New System.Drawing.Point(96, 88)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(136, 20)
        Me.txtLabel.TabIndex = 2
        '
        'btSend
        '
        Me.btSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSend.Location = New System.Drawing.Point(240, 16)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(56, 56)
        Me.btSend.TabIndex = 3
        Me.btSend.Text = "&Send"
        '
        'txtMsg
        '
        Me.txtMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMsg.Location = New System.Drawing.Point(96, 16)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMsg.Size = New System.Drawing.Size(136, 56)
        Me.txtMsg.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Body Text"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMsg)
        Me.GroupBox1.Controls.Add(Me.btSend)
        Me.GroupBox1.Controls.Add(Me.txtLabel)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(280, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 120)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message"
        '
        'txtQueue
        '
        Me.txtQueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQueue.Location = New System.Drawing.Point(96, 24)
        Me.txtQueue.Name = "txtQueue"
        Me.txtQueue.Size = New System.Drawing.Size(136, 20)
        Me.txtQueue.TabIndex = 4
        '
        'btCreate
        '
        Me.btCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCreate.Location = New System.Drawing.Point(240, 16)
        Me.btCreate.Name = "btCreate"
        Me.btCreate.Size = New System.Drawing.Size(56, 32)
        Me.btCreate.TabIndex = 5
        Me.btCreate.Text = "&Create"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btCreate)
        Me.GroupBox2.Controls.Add(Me.txtQueue)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(280, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 64)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Queue"
        '
        'txtBody
        '
        Me.txtBody.Enabled = False
        Me.txtBody.Location = New System.Drawing.Point(280, 240)
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBody.Size = New System.Drawing.Size(296, 64)
        Me.txtBody.TabIndex = 15
        '
        'btRefresh
        '
        Me.btRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRefresh.Location = New System.Drawing.Point(400, 328)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(96, 32)
        Me.btRefresh.TabIndex = 8
        Me.btRefresh.Text = "&Refresh Tree"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(280, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Message Body"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 373)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btDelete)
        Me.Controls.Add(Me.btRecive)
        Me.Name = "Form1"
        Me.Text = "MSMQ Manager.NET"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSend.Click
        Try

            Dim queue As New MessageQueue()
            queue.Path = ".\" & TreeView1.SelectedNode.Text
            Dim node As New TreeNode()
            If TreeView1.SelectedNode.Tag = "Queue" Then
                node.Text = txtLabel.Text
                node.Tag = "Message"
                queue.Send(txtMsg.Text, txtLabel.Text)
                TreeView1.Nodes(TreeView1.SelectedNode.Index).Nodes.Add(node)
                txtMsg.Text = ""
                txtLabel.Text = ""
            Else
                MessageBox.Show("Please select a queue")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub btRecive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecive.Click
        Try

            If TreeView1.SelectedNode.Tag = "Message" Then
                Dim msg As Message
                Dim queue As New MessageQueue()
                queue.Path = ".\" & TreeView1.SelectedNode.Parent.Text
                If MessageBox.Show("Are you sure you want to delete this message?", "Delete ?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    msg = queue.Receive(New TimeSpan(1000))
                    MessageBox.Show("Messsage labelled """ & msg.Label & """ deleted successfully")
                    RefreshTree()
                End If
            Else
                MessageBox.Show("Please select a message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub


    Private Sub btCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreate.Click
        Try
            MessageQueue.Create(".\Private$\" & txtQueue.Text)
            RefreshTree()
        Catch ex As MessageQueueException
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshTree()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        Try

            If TreeView1.SelectedNode.Tag = "Queue" Then
                If MessageBox.Show("Are you sure you want to delete the queue and all its messages ?", "Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    MessageQueue.Delete(".\" & TreeView1.SelectedNode.Text)
                    TreeView1.Nodes.RemoveAt(TreeView1.SelectedNode.Index)
                    MessageBox.Show("Queue deleted successfully.")
                End If
            Else
                MessageBox.Show("Please select a queue.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    Private Sub RefreshTree()
        Try
            Dim queue As MessageQueue
            TreeView1.Nodes.Clear()
            TreeView1.BeginUpdate()
            Dim allprivatequeus() As MessageQueue = MessageQueue.GetPrivateQueuesByMachine("localhost")
            For Each queue In allprivatequeus
                Dim qNode As New TreeNode()
                qNode.Text = queue.QueueName
                qNode.Tag = "Queue"
                TreeView1.Nodes.Add(qNode)
                Dim m As Message
                For Each m In queue
                    Dim mNode As New TreeNode()
                    mNode.Tag = "Message"
                    mNode.Text = m.Label
                    TreeView1.Nodes(Array.IndexOf(allprivatequeus, queue)).Nodes.Add(mNode)
                Next
            Next
            TreeView1.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Click
        RefreshTree()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            If TreeView1.SelectedNode.Tag = "Message" Then
                Dim queue As New MessageQueue(".\" & TreeView1.SelectedNode.Parent.Text)
                queue.Formatter = New XmlMessageFormatter(New String() {"System.String"})
                Dim qenum As MessageEnumerator
                qenum = queue.GetMessageEnumerator
                While qenum.MoveNext
                    Dim m As Message = qenum.Current
                    If m.Label = TreeView1.SelectedNode.Text Then
                        txtBody.Text = m.Body
                        Exit While
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
