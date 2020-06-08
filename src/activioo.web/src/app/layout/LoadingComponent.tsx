import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

export const LoadingComponent: React.FC<{
  inverted?: boolean;
  content?: string;
}> = ({ inverted = true, content }) => {
  return (
    <Dimmer active inverted={inverted}>
      <Loader size='big' content={content} />
    </Dimmer>
  );
};
