export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    normalPulse: number;
    avgSleepTime: number;
    activityLevel: ActivityLevel
}

export enum ActivityLevel {
    Low,
    Normal,
    VeryActive
}