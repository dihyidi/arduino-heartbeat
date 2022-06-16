import React, { useEffect, useMemo, useState } from 'react'
import { Button } from 'semantic-ui-react';
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import { startCount } from '../../app/services/pulseDataService';
import { PulseChart } from './PulseChart';
import { selectPulse, fetchUserPulseAsync } from './pulseSlice';
import { PulseTable } from './PulseTable';

export const PulseOverview = () => {
    const pulse = useAppSelector(selectPulse);
    const dispatch = useAppDispatch();
    const [showTable, setShowTable] = useState(false)

    useEffect(() => {
        dispatch(fetchUserPulseAsync(1));
    }, []);

    const divider = useMemo(() => <div style={{ margin: '1vh' }} />, []);

    const start = () => {
        startCount(1);
        setTimeout(() => {
            dispatch(fetchUserPulseAsync(1));
        }, 20000);
    }

    return (
        <div style={{ margin: '2vh 0 0 2vh', display: 'flex', flexDirection: 'column', height: 'auto', overflow: 'auto', justifyContent: 'space-between', alignItems: 'center' }}>
            <PulseChart pulse={pulse} />
            {divider}
            <Button color='purple' size='big' onClick={() => start()}>Start</Button>
            {divider}
            <Button color='grey' size='big' icon={showTable ? 'chevron up' : "chevron down"} content={showTable ? "Show less" : "Show more"} onClick={() => setShowTable(!showTable)} />
            {divider}
            {showTable && <PulseTable pulse={pulse} />}
        </div>
    )
}
