import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Task } from '../../store/reducers/task.reducer';
import { loadTasks, deleteTask } from '../../store/actions/task.actions';
import { selectAllTasks } from '../../store/selectors/task.selectors';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TaskListComponent implements OnInit {
  tasks$: Observable<Task[]>;

  constructor(private store: Store<{ tasks: Task[] }>) {
    this.tasks$ = this.store.pipe(select(selectAllTasks));
  }

  ngOnInit(): void {
    this.store.dispatch(loadTasks());
  }

  onDeleteTask(taskId: string): void {
    this.store.dispatch(deleteTask({ taskId }));
  }
}