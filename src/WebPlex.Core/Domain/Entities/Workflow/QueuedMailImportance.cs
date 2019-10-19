namespace WebPlex.Core.Domain.Entities.Workflow {
	public enum QueuedMailImportance : byte {
		Low = 0,
		Normal = 1,
		High = 2,
		Critical = 4
	}
}