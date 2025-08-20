export interface Task {
  id: string;
  title: string;
  description?: string;
  listId: string;
  createdAt: string;
  dueDate?: string;
  assignedUserId?: string;
  likes?: number;
  dislikes?: number;
}
