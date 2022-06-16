import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import counterReducer from '../features/counter/counterSlice';
import pulseReducer from '../features/pulse/pulseSlice';
import userReducer from "../features/user/userSlice"

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    pulse: pulseReducer,
    user: userReducer
  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
