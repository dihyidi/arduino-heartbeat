import axios, { AxiosResponse } from "axios";
import { Pulse } from "../../features/pulse/pulse";

export const getPulseByUserId = (id: number): Promise<AxiosResponse<Pulse[], any>> => axios.get(`/api/pulse/${id}`);

export const startCount = (id: number) => axios.post(`/api/pulse/${id}`);