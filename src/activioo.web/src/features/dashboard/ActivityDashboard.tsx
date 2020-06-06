import React from 'react'
import { Grid, GridColumn, List } from 'semantic-ui-react';
import { IActivity } from '../../app/models/activity';
import { ActivityList } from './ActivityList';

interface IProps {
  activities: IActivity[]
}

export const ActivityDashboard: React.FC<IProps> = ({activities}) => {
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList activities={activities}/>
      {/* <List>
          {activities.map((activity) => (
            <List.Item key={activity.id}>
              {activity.title} {activity.city}
            </List.Item>
          ))}
        </List> */}
      </GridColumn>
    </Grid>
  )
}
