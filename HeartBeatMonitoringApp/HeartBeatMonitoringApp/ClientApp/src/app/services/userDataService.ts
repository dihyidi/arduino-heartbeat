import axios, { AxiosResponse } from "axios";
import { User } from "../../features/user/user";

export const getUserById = (id: number): Promise<AxiosResponse<User, any>> => axios.get(`/users/${id}`);