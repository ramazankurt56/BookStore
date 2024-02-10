export class RequestModel{
    pageSize:number=12;
    pageNumber:number=1;
   search:string="";
    categoryId:number|null=null;
    author:string|null=null;
    filter:string="default"
}