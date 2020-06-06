import React from "react";
import { Grid, GridColumn} from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";
import { ActivityList } from "./ActivityList";
import { ActivityDetails } from "./../details/ActivityDetails";
import { ActivityForm } from "./../form/ActivityForm";

interface IProps {
  activities: IActivity[];
  selectActivity: (id: string) => void;
  selectedActivity: IActivity | null;
}

export const ActivityDashboard: React.FC<IProps> = ({
  activities,
  selectActivity,
  selectedActivity
}) => {
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList activities={activities} selectActivity={selectActivity} />
      </GridColumn>
      <Grid.Column width={6}>
        {selectedActivity && <ActivityDetails activity={selectedActivity} />}
        <ActivityForm />
      </Grid.Column>
    </Grid>
  );
};
