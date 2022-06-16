import React, { useMemo } from 'react'
import { AxisOptions, Chart } from 'react-charts'
import { Pulse } from './pulse';
import { ResizableBox } from './ResizableBox';
import { formatDate } from './utils';

export const PulseChart = (props: { pulse: Pulse[] }) => {
    const data = [
        {
            label: "Pulse Chart",
            data: props.pulse
        }
    ];

    const primaryAxis = useMemo((): AxisOptions<Pulse> => ({
        getValue: datum => formatDate(datum.date),
    }), []);

    const secondaryAxes = useMemo((): AxisOptions<Pulse>[] => [{
        getValue: datum => datum.count,
    },
    ], []);

    return (
        <ResizableBox style={{ width: '60%' }}>
            <Chart
                options={{
                    data,
                    primaryAxis,
                    secondaryAxes,
                }}
            />
        </ResizableBox>
    )
}
