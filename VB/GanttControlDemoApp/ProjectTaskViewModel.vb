Imports System
Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm.Gantt

Namespace GanttControlDemoApp
	Public Class ProjectTaskViewModel
		Public Sub New()
			Tasks = New ObservableCollection(Of GanttTask) From {
				New GanttTask() With {
					.Id = 0,
					.Name = "Add a new feature",
					.StartDate = DateTime.Now.AddDays(-1),
					.FinishDate = DateTime.Now.AddDays(6)
				},
				New GanttTask() With {
					.Id = 1,
					.ParentId = 0,
					.Name = "Write the code",
					.StartDate = DateTime.Now.AddDays(-1),
					.FinishDate = DateTime.Now.AddDays(2)
				},
				New GanttTask() With {
					.Id = 2,
					.ParentId = 0,
					.Name = "Write the docs",
					.StartDate = DateTime.Now.AddDays(2),
					.FinishDate = DateTime.Now.AddDays(5)
				},
				New GanttTask() With {
					.Id = 3,
					.ParentId = 0,
					.Name = "Test the new feature",
					.StartDate = DateTime.Now.AddDays(2),
					.FinishDate = DateTime.Now.AddDays(5)
				},
				New GanttTask() With {
					.Id = 4,
					.ParentId = 0,
					.Name = "Release the new feature",
					.StartDate = DateTime.Now.AddDays(5),
					.FinishDate = DateTime.Now.AddDays(5)
				}
			}
			' the "Release the new feature" task can begin only when the "Write the docs" task is complete
			Tasks(4).PredecessorLinks.Add(New GanttPredecessorLink() With {
				.PredecessorTaskId = 2,
				.LinkType = PredecessorLinkType.FinishToStart
			})
			' the "Release the new feature" task can begin only when the "Test the new feature" task is complete
			Tasks(4).PredecessorLinks.Add(New GanttPredecessorLink() With {
				.PredecessorTaskId = 3,
				.LinkType = PredecessorLinkType.FinishToStart
			})
			' the "Write the docs" task can begin only when the "Write the code" task is complete
			Tasks(2).PredecessorLinks.Add(New GanttPredecessorLink() With {
				.PredecessorTaskId = 1,
				.LinkType = PredecessorLinkType.FinishToStart
			})
			' the "Test the new feature" task can begin only when the "Write the code" task is complete
			Tasks(3).PredecessorLinks.Add(New GanttPredecessorLink() With {
				.PredecessorTaskId = 1,
				.LinkType = PredecessorLinkType.FinishToStart
			})
		End Sub

		Public Property Tasks() As ObservableCollection(Of GanttTask)
	End Class
End Namespace
