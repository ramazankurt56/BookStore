import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'authorr'
})
export class AuthorPipe implements PipeTransform {

  transform(value: any[], search:string) {
    if(search==="") return value;
    console.log(search)
    return value.filter(p=> p.author.toLowerCase().includes(search.toLowerCase()))
  }

}

