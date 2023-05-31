export interface Period {
    id: number;
    name: string;
    startTime: string;
    endTime: string;
  }

export function getDefaultPeriod(): Period {
  return {
    id: 0,
    name: '',
    startTime: '',
    endTime: ''
  };
}