Imports System.Messaging

Public Class frmMSMQ

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

    Private Sub btCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreate.Click
        Try
            MessageQueue.Create(".\Private$\" & txtQueue.Text)
            RefreshTree()
        Catch ex As MessageQueueException
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Click
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

    Private Sub frmMSMQ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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