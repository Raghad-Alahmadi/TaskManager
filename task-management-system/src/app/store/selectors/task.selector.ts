import { createSelector } from '@ngrx/store';

export const selectTaskState = (state: AppState) => state.tasks;
export const selectAllTasks = createSelector(selectTaskState, (state) => state.tasks);