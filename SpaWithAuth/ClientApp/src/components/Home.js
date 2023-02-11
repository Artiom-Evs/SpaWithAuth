import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
      super(props);
      this.state = { user: null };
    }

    componentDidMount() {
      this.loadData();
    }

    async loadData() {
        let user = await authService.getUser();
      this.setState({ user: user });
    }

    render() {
      let { user } = this.state;
      
    return (
      <div>
            <h1>Claims</h1>
            {JSON.stringify(user)}
      </div>
    );
  }
}
