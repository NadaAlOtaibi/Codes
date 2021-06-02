import React, { Component } from 'react'
import axios from 'axios'
export default class App extends Component {
  constructor(props){  
    super(props);
    this.state={
      data:{}
    }
}
componentDidMount(){
    this.callApi()
}
callApi(){
axios({
    method:"get",
    url:"https://pokeapi.co/api/v2/pokemon/ditto"
}).then((res) => {
    console.log("this responce",res.data)
    this.setState({data:res.data})
} 
).catch((error) =>{
console.log("Error",error)
})}

render() {
    return (
        <div>
            <h1>Api App</h1>
            <h2>{this.state.data.id}</h2>
        </div>
    )
}
}
