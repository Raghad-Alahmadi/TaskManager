import { bootstrapApplication } from '@angular/platform-browser';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideHttpClient, withFetch } from '@angular/common/http';

import { AppComponent } from './app/app.component';
import { taskReducer } from './app/store/reducers/task.reducer';
import { TaskEffects } from './app/store/effects/task.effects';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(withFetch()),
    provideStore({ tasks: taskReducer }),
    provideEffects(TaskEffects),
    provideStoreDevtools({ maxAge: 25 })
  ]
}).catch(err => console.error(err));