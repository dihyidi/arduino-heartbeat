import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { getPulseByUserId } from "../../app/services/pulseDataService";
import { AppDispatch, RootState } from "../../app/store";
import { Pulse, TriggerType } from "./pulse";

const initialState: Pulse[] = [{
    id: 0,
    count: 0,
    date: "",
    triggerType: TriggerType.Automatic
}]

export const fetchUserPulseAsync = (id: number) => async (dispatch: AppDispatch) => {
    try {
        const res = await getPulseByUserId(id);
        dispatch(fetchAll(res.data))
    }
    catch (e) {
        console.log(e);
    }
}

export const pulseSlice = createSlice({
    name: "pulse",
    initialState,
    reducers: {
        fetchAll: (state, action: PayloadAction<Pulse[]>) => {
            state = [...action.payload];
            return state;
        }
    }
});

export const { fetchAll } = pulseSlice.actions;

export const selectPulse = (state: RootState) => state.pulse;

export default pulseSlice.reducer;