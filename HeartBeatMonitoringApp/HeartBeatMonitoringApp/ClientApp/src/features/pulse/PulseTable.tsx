import { Icon, Menu, Table } from 'semantic-ui-react';
import { Pulse, TriggerType } from './pulse';
import { formatDate } from './utils';

const TOP = 10;

export const PulseTable = (props: { pulse: Pulse[] }) => {
    const pagesCount = props.pulse.length / TOP;

    const printPagination = () => {
        for (let index = 1; index <= pagesCount; index++) {
            return <Menu.Item as='a'>{index}</Menu.Item>
        }
    }

    return (
        <div style={{ width: '60%' }}>
            <Table celled>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Date</Table.HeaderCell>
                        <Table.HeaderCell>Count</Table.HeaderCell>
                        <Table.HeaderCell>Triggered by</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {props.pulse.map(item =>
                        <Table.Row key={item.id}>
                            <Table.Cell>{formatDate(item.date)}</Table.Cell>
                            <Table.Cell>{item.count}</Table.Cell>
                            <Table.Cell>{TriggerType[item.triggerType]}</Table.Cell>
                        </Table.Row>
                    )}
                </Table.Body>
                <Table.Footer>
                    <Table.Row>
                        <Table.HeaderCell colSpan='3'>
                            <Menu floated='right' pagination>
                                <Menu.Item as='a' icon>
                                    <Icon name='chevron left' />
                                </Menu.Item>
                                {printPagination()}
                                <Menu.Item as='a' icon>
                                    <Icon name='chevron right' />
                                </Menu.Item>
                            </Menu>
                        </Table.HeaderCell>
                    </Table.Row>
                </Table.Footer>
            </Table>
        </div>
    )
}


