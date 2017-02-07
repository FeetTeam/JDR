/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    public interface ICharacterClass
    {
        string Name { get; }
        string Description { get; }
        List<ClassFeat>[] ClassFeats { get; }
    }
}