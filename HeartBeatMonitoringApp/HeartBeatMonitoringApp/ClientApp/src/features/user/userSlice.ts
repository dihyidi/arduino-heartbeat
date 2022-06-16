import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import { getUserById } from "../../app/services/userDataService";
import { RootState } from "../../app/store";
import { ActivityLevel, User } from "./user";

const initialState: User = {
    id: 0,
    firstName: "",
    lastName: "",
    email: "",
    normalPulse: 0,
    avgSleepTime: 0,
    activityLevel: ActivityLevel.Low
}

export const getByIdAsync = createAsyncThunk("user/fetchById", async (id: number) => {
    const res = await getUserById(id);
    return res.data;
})

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        fetchById: (state, action: PayloadAction<User>) => {
            state = action.payload
        }
    }
});

export const { fetchById } = userSlice.actions;

export const selectUser = (state: RootState) => state.user;

export default userSlice.reducer;