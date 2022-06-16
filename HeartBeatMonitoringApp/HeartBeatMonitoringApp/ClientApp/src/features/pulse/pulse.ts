export interface Pulse {
    id: number;
    count: number;
    date: string;
    triggerType: TriggerType
}

export enum TriggerType {
    Automatic,
    Manually
}